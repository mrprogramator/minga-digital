using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.StaticFiles;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.Diagnostics;

using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;

using Newtonsoft.Json.Serialization;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Filters;
using MingaDigital.App.Services;
using MingaDigital.App.Metadata;

namespace MingaDigital.App
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        
        public Startup()
        {
            Configuration = LoadConfiguration();
        }
        
        public static IConfiguration LoadConfiguration() =>
            new Configuration()
            .AddJsonFile("config.json")
            .AddEnvironmentVariables();
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // Desabilitado!
            // services.Configure<MvcOptions>(ConfigureJsonFormatter);
            services.Configure<MvcOptions>(ConfigureGlobalFilters);
            services.Configure<MvcOptions>(ConfigureMetadataProviders);
            
            services.AddSingleton<ActionScavenger>();
            
            services.AddScoped<UserSessionService>();
            services.AddScoped<UserPermissionsService>();
            
            AddDataServices(services);
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorPage(ErrorPageOptions.ShowAll);
            
            UseRedirectOnException<System.Data.DataException>(app, "/error/db-conn");
            
            app.UseStatusCodePages();
            
            app.UseMvc();
            
            app.UseStaticFiles();
            
            if (Directory.Exists("bower_components"))
                ServeDirectory(app, "bower_components", "/bower_components");
        }
        
        // TODO organizar
        private static void ServeDirectory(IApplicationBuilder app, String directoryPath, String requestPath)
        {
            // TODO utilizar directorio de proyecto (solo si ruta es relativa)
            var currentDirectory = Directory.GetCurrentDirectory();
            var fullPath = Path.Combine(currentDirectory, directoryPath);
            
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
