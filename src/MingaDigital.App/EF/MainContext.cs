using System;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MingaDigital.App.Entities;
using MingaDigital.Security;

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
        
        public DbSet<SesionUsuario> SesionUsuario { get; set; }
        
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
        
        // TODO hack-ish
        private readonly IList<Type> _complexTypes = new List<Type>();
        
        private void MakeComplexType<T>(DbModelBuilder modelBuilder)
            where T : class
        {
            _complexTypes.Add(typeof(T));
            modelBuilder.ComplexType<T>();
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            
            MakeComplexType<GeoCoordenada>(modelBuilder);
            
            // <password>
            
            MakeComplexType<Password>(modelBuilder);
            
            modelBuilder
                .ComplexType<Password>()
                .Property(p => p.Hash)
                .IsRequired();
            
            modelBuilder
                .ComplexType<Password>()
                .Property(p => p.Salt)
                .IsRequired();
            
            modelBuilder
                .ComplexType<Password>()
                .Property(p => p.Algorithm)
                .IsRequired();
            
            // </password>
            
            modelBuilder
                .Entity<UnidadEducativa>()
                .HasOptional(ue => ue.Ctel)
                .WithRequired(ct => ct.UnidadEducativa)
                .WillCascadeOnDelete();
            
            modelBuilder
                .Entity<PersonaFisica>()
                .HasOptional(p => p.Usuario)
                .WithRequired(u => u.PersonaFisica)
                .WillCascadeOnDelete();
            
            modelBuilder
                .Types()
                .Configure(config => config.ToTable(GetTableName(config.ClrType)));
            
            modelBuilder
                .Properties()
                .Configure(config => config.HasColumnName(GetColumnName(config.ClrPropertyInfo)));
            
            base.OnModelCreating(modelBuilder);
        }
        
        private String GetTableName(Type type)
        {
            return PascalCaseToLowerUnderscore(type.Name);
        }
        
        private String GetColumnName(PropertyInfo property)
        {
            String columnName = "";
            
            if (_complexTypes.Contains(property.DeclaringType))
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
