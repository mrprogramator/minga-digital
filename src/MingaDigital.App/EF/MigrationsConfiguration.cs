using System.Data.Entity;
using System.Data.Entity.Migrations;

using MingaDigital.App.Entities;

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
            // pass
        }
    }
}