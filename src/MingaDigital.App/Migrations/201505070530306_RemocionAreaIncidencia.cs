namespace MingaDigital.App.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemocionAreaIncidencia : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.tipo_incidencia", "area_id", "public.area_incidencia");
            DropIndex("public.area_incidencia", new[] { "nombre" });
            DropIndex("public.tipo_incidencia", new[] { "area_id" });
            DropColumn("public.tipo_incidencia", "area_id");
            DropTable("public.area_incidencia");
        }
        
        public override void Down()
        {
            CreateTable(
                "public.area_incidencia",
                c => new
                    {
                        area_incidencia_id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.area_incidencia_id);
            
            AddColumn("public.tipo_incidencia", "area_id", c => c.Int(nullable: false));
            CreateIndex("public.tipo_incidencia", "area_id");
            CreateIndex("public.area_incidencia", "nombre", unique: true);
            AddForeignKey("public.tipo_incidencia", "area_id", "public.area_incidencia", "area_incidencia_id", cascadeDelete: true);
        }
    }
}
