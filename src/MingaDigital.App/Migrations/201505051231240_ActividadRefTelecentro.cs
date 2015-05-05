namespace MingaDigital.App.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActividadRefTelecentro : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.actividad", "unidad_educativa_id", "public.unidad_educativa");
            DropIndex("public.actividad", new[] { "unidad_educativa_id" });
            AddColumn("public.actividad", "telecentro_id", c => c.Int(nullable: false));
            CreateIndex("public.actividad", "telecentro_id");
            AddForeignKey("public.actividad", "telecentro_id", "public.telecentro", "establecimiento_minga_id");
            DropColumn("public.actividad", "unidad_educativa_id");
        }
        
        public override void Down()
        {
            AddColumn("public.actividad", "unidad_educativa_id", c => c.Int(nullable: false));
            DropForeignKey("public.actividad", "telecentro_id", "public.telecentro");
            DropIndex("public.actividad", new[] { "telecentro_id" });
            DropColumn("public.actividad", "telecentro_id");
            CreateIndex("public.actividad", "unidad_educativa_id");
            AddForeignKey("public.actividad", "unidad_educativa_id", "public.unidad_educativa", "unidad_educativa_id", cascadeDelete: true);
        }
    }
}
