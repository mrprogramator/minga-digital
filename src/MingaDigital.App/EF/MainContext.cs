using System;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Data.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MingaDigital.App.Entities;

namespace MingaDigital.App.EF
{
    [DbConfigurationType(typeof(Npgsql.NpgsqlEFConfiguration))]
    public class MainContext : DbContext
    {
        public DbSet<Actividad> Actividad { get; set; }
        
        public DbSet<TipoActividad> TipoActividad { get; set; }
        
        public DbSet<Persona> Persona { get; set; }
        
        public DbSet<UnidadEducativa> UnidadEducativa { get; set; }
        
        public DbSet<Usuario> Usuario { get; set; }
        
        public DbSet<Rol> Rol { get; set; }
        
        public DbSet<Accion> Accion { get; set; }
        
        public DbSet<PermisoRol> PermisoRol { get; set; }
        
        public DbSet<PermisoGlobal> PermisoGlobal { get; set; }
        
        public DbSet<UsuarioRol> UsuarioRol { get; set; }
        
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
            String columnName = "";
            
            if (property.ReflectedType.GetCustomAttribute<ComplexTypeAttribute>() != null)
            {
                columnName += property.DeclaringType.Name + "_";
            }
            
            columnName +=
                Regex.Replace(
                    property.Name,
                    ".[A-Z]",
                    m => m.Value[0] + "_" + m.Value[1]);
            
            return columnName.ToLower();
        }
    }
}