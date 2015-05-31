using System.Data.Entity;
using System.Data.Entity.Migrations;

using MingaDigital.App.Entities;
using MingaDigital.Security;

namespace MingaDigital.App.EF
{
    public class MigrationsConfiguration : DbMigrationsConfiguration<MainContext>
    {
        public MigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }
        
        protected override void Seed(MainContext db)
        {
            var personaAdmin = new PersonaFisica
            {
                Nombres = "Admin",
                Apellidos = "Admin"
            };
            
            db.PersonaFisica.AddOrUpdate(x => x.Nombres, personaAdmin);
            
            var usuarioAdmin = new Usuario
            {
                PersonaFisica = personaAdmin,
                Username = "admin",
                Password = PasswordHash.Plain("admin")
            };
            
            db.Usuario.AddOrUpdate(x => x.Username, usuarioAdmin);
        }
    }
}