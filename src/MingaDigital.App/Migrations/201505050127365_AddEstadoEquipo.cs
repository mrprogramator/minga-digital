namespace MingaDigital.App.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEstadoEquipo : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.equipo", "estado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.equipo", "estado");
        }
    }
}
