namespace MingaDigital.App.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.actividad",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titulo = c.String(nullable: false),
                        descripcion = c.String(),
                        tiempo_inicio = c.DateTimeOffset(nullable: false, precision: 7),
                        tiempo_fin = c.DateTimeOffset(nullable: false, precision: 7),
                        realizado = c.Boolean(nullable: false),
                        tipo_actividad_id = c.Int(nullable: false),
                        usuario_creador_id = c.Int(nullable: false),
                        persona_encargada_id = c.Int(nullable: false),
                        unidad_educativa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.persona", t => t.persona_encargada_id, cascadeDelete: true)
                .ForeignKey("public.tipo_actividad", t => t.tipo_actividad_id, cascadeDelete: true)
                .ForeignKey("public.unidad_educativa", t => t.unidad_educativa_id, cascadeDelete: true)
                .ForeignKey("public.usuario", t => t.usuario_creador_id, cascadeDelete: true)
                .Index(t => t.tipo_actividad_id)
                .Index(t => t.usuario_creador_id)
                .Index(t => t.persona_encargada_id)
                .Index(t => t.unidad_educativa_id);
            
            CreateTable(
                "public.persona",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.tipo_actividad",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.unidad_educativa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.actividad", "usuario_creador_id", "public.usuario");
            DropForeignKey("public.actividad", "unidad_educativa_id", "public.unidad_educativa");
            DropForeignKey("public.actividad", "tipo_actividad_id", "public.tipo_actividad");
            DropForeignKey("public.actividad", "persona_encargada_id", "public.persona");
            DropIndex("public.actividad", new[] { "unidad_educativa_id" });
            DropIndex("public.actividad", new[] { "persona_encargada_id" });
            DropIndex("public.actividad", new[] { "usuario_creador_id" });
            DropIndex("public.actividad", new[] { "tipo_actividad_id" });
            DropTable("public.usuario");
            DropTable("public.unidad_educativa");
            DropTable("public.tipo_actividad");
            DropTable("public.persona");
            DropTable("public.actividad");
        }
    }
}
