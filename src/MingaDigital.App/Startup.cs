using System;
using System.IO;
using System.Linq;

using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.StaticFiles;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.Diagnostics;

using Microsoft.Framework.Runtime;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;

using Newtonsoft.Json.Serialization;

using MingaDigital.App.EF;
using MingaDigital.App.Filters;
using MingaDigital.App.Services;
using MingaDigital.App.Metadata;
using MingaDigital.App.Validators;

namespace MingaDigital.App
{
    public class Startup
    {
        private readonly IApplicationEnvironment _appEnv;
        
        public IConfiguration Configuration { get; private set; }
        
        public Startup(IApplicationEnvironment appEnv)
        {
            _appEnv = appEnv;
            Configuration = LoadConfiguration();
        }
        
        public static IConfiguration LoadConfiguration() =>
            new Configuration()
            .AddJsonFile("config.json")
            .AddEnvironmentVariables();
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // services.Configure<MvcOptions>(ConfigureJsonFormatter);
            services.Configure<MvcOptions>(ConfigureGlobalFilters);
            services.Configure<MvcOptions>(ConfigureMetadataProviders);
            services.Configure<MvcOptions>(ConfigureValidatorProviders);
            
            services.AddSingleton<ActionScavenger>();
            
            services.AddScoped<UserSessionService>();
            services.AddScoped<UserPermissionsService>();
            
            AddDataServices(services);
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorPage(ErrorPageOptions.ShowAll);
            
            // UseRedirectOnException<System.Data.DataException>(app, "/error/db-conn");
            
            app.UseStatusCodePages();
            
            app.UseMvc();
            
            app.UseStaticFiles();
            
            if (Directory.Exists("bower_components"))
                ServeDirectory(app, "bower_components", "/bower_components");
        }
        
        private void ServeDirectory(IApplicationBuilder app, String directoryPath, String requestPath)
        {
            var fullPath = Path.Combine(_appEnv.ApplicationBasePath, directoryPath);
            
            app.UseStaticFiles(new StaticFileOptions()
            {
                RequestPath = new PathString(requestPath),
                FileProvider = new PhysicalFileProvider(fullPath)
            });
        }
        
        private void ConfigureJsonFormatter(MvcOptions options)
        {
            var settings = 
                options.OutputFormatters
                       .Select(f => f.Instance as JsonOutputFormatter)
                       .First(f => f != null)
                       .SerializerSettings;
            
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
        
        private void ConfigureGlobalFilters(MvcOptions options)
        {
            options.Filters.Add(typeof(UserSessionFilter));
        }
        
        private void ConfigureMetadataProviders(MvcOptions options)
        {
            options.ModelMetadataDetailsProviders.Add(new AdditionalMetadataProvider());
        }
        
        private void ConfigureValidatorProviders(MvcOptions options)
        {
            // Instantiated like a scoped service (:
            options.ModelValidatorProviders.Add(typeof(EntitySelectorValidatorProvider));
        }
        
        private void AddDataServices(IServiceCollection services)
        {
            services.AddSingleton(serviceProvider =>
            {
                return new MainContextFactory(Configuration);
            });
            
            services.AddScoped(serviceProvider =>
            {
                var factory = serviceProvider.GetRequiredService<MainContextFactory>();
                
                return factory.Create();
            });
        }
        
        // TODO organizar
        private void UseRedirectOnException<ExceptionT>(IApplicationBuilder app, String targetUrl)
            where ExceptionT : Exception
        {
            app.Use(next =>
            {
                return async (HttpContext ctx) =>
                {
                    try
                    {
                        await next(ctx);
                    }
                    catch (ExceptionT)
                    {
                        ctx.Response.Redirect(targetUrl);
                    }
                };
            });
        }
    }
}
