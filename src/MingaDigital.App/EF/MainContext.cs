using System;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Data.Entity;

using MingaDigital.App.Entities;

namespace MingaDigital.App.EF
{
    [DbConfigurationType(typeof(Npgsql.NpgsqlEFConfiguration))]
    public class MainContext : DbContext
    {
        public DbSet<Activity> Activity { get; set; }
        
        public MainContext(String connectionString)
            : base(connectionString)
        {
            Database.Log = Console.Error.WriteLine;
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            
            modelBuilder
                .Properties()
                .Configure(config => config.HasColumnName(GetColumnName(config.ClrPropertyInfo)));
            
            base.OnModelCreating(modelBuilder);
        }

        private static string GetColumnName(PropertyInfo property)
        {
            var result =
                Regex.Replace(
                    property.Name,
                    ".[A-Z]",
                    m => m.Value[0] + "_" + m.Value[1]);

            return result.ToLower();
        }
    }
}