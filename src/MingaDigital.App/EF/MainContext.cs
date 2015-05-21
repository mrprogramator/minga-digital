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
        public DbSet<Accion> Accion { get; set; }
        
        public DbSet<Actividad> Actividad { get; set; }
        
        public DbSet<ActivoMinga> ActivoMinga { get; set; }
        
        public DbSet<Almacen> Almacen { get; set; }
        
        public DbSet<Componente> Componente { get; set; }
        
        public DbSet<Ctel> Ctel { get; set; }
        
        public DbSet<Equipo> Equipo { get; set; }
        
        public DbSet<EstablecimientoMinga> EstablecimientoMinga { get; set; }
        
        public DbSet<ItemMovimiento> ItemMovimiento { get; set; }
        
        public DbSet<Movimiento> Movimiento { get; set; }
        
        public DbSet<Municipio> Municipio { get; set; }
        
        public DbSet<PermisoGlobal> PermisoGlobal { get; set; }
        
        public DbSet<PermisoRol> PermisoRol { get; set; }
        
        public DbSet<PersonaFisica> PersonaFisica { get; set; }
        
        public DbSet<PersonaFisicaCtel> PersonaFisicaCtel { get; set; }
        
        public DbSet<PersonaJuridica> PersonaJuridica { get; set; }
        
        public DbSet<Rol> Rol { get; set; }
        
        public DbSet<Telecentro> Telecentro { get; set; }
        
        public DbSet<Ticket> Ticket { get; set; }
        
        public DbSet<TipoActividad> TipoActividad { get; set; }

        public DbSet<TipoComponente> TipoComponente { get; set; }
        
        public DbSet<TipoIncidencia> TipoIncidencia { get; set; }
        
        public DbSet<Ubicacion> Ubicacion { get; set; }
        
        public DbSet<UnidadEducativa> UnidadEducativa { get; set; }
        
        public DbSet<Usuario> Usuario { get; set; }
        
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
                .Entity<UnidadEducativa>()
                .HasOptional(ue => ue.Ctel)
                .WithRequired(ct => ct.UnidadEducativa);
            
            modelBuilder
                .Types()
                .Configure(config => config.ToTable(GetTableName(config.ClrType)));
            
            modelBuilder
                .Properties()
                .Configure(config => config.HasColumnName(GetColumnName(config.ClrPropertyInfo)));
            
            base.OnModelCreating(modelBuilder);
        }
        
        private static String GetTableName(Type type)
        {
            return PascalCaseToLowerUnderscore(type.Name);
        }
        
        private static String GetColumnName(PropertyInfo property)
        {
            String columnName = "";
            
            if (property.ReflectedType.GetCustomAttribute<ComplexTypeAttribute>() != null)
            {
                columnName += PascalCaseToLowerUnderscore(property.DeclaringType.Name) + "_";
            }
            
            columnName += PascalCaseToLowerUnderscore(property.Name);
            
            return columnName;
        }
        
        private static String PascalCaseToLowerUnderscore(String source)
        {
            var result =
                Regex.Replace(
                    source,
                    ".[A-Z]",
                    m => m.Value[0] + "_" + m.Value[1]);
            
            return result.ToLower();
        }
    }
}
