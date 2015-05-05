namespace MingaDigital.App.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UEAsociacionTelecentro : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.unidad_educativa", "telecentro_id", c => c.Int(nullable: false));
            CreateIndex("public.unidad_educativa", "telecentro_id");
            AddForeignKey("public.unidad_educativa", "telecentro_id", "public.telecentro", "establecimiento_minga_id");
        }
        
        public override void Down()
        {
            DropForeignKey("public.unidad_educativa", "telecentro_id", "public.telecentro");
            DropIndex("public.unidad_educativa", new[] { "telecentro_id" });
            DropColumn("public.unidad_educativa", "telecentro_id");
        }
    }
}
