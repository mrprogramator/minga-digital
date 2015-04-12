namespace MingaDigital.App.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncidenciasInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.area_incidencia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.equipo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.estado_ticket",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.incidencia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(nullable: false),
                        prioridad = c.Int(nullable: false),
                        area_incidencia_id = c.Int(nullable: false),
                        ticket_id = c.Int(nullable: false),
                        tipo_incidencia_id = c.Int(nullable: false),
                        telecentro_id = c.Int(nullable: false),
                        equipo_id = c.Int(nullable: false),
                        usuario_id = c.Int(nullable: false),
                        encargado_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.area_incidencia", t => t.area_incidencia_id, cascadeDelete: true)
                .ForeignKey("public.usuario", t => t.encargado_id, cascadeDelete: true)
                .ForeignKey("public.equipo", t => t.equipo_id, cascadeDelete: true)
                .ForeignKey("public.telecentro", t => t.telecentro_id, cascadeDelete: true)
                .ForeignKey("public.ticket", t => t.ticket_id, cascadeDelete: true)
                .ForeignKey("public.tipo_incidencia", t => t.tipo_incidencia_id, cascadeDelete: true)
                .ForeignKey("public.usuario", t => t.usuario_id, cascadeDelete: true)
                .Index(t => t.area_incidencia_id)
                .Index(t => t.ticket_id)
                .Index(t => t.tipo_incidencia_id)
                .Index(t => t.telecentro_id)
                .Index(t => t.equipo_id)
                .Index(t => t.usuario_id)
                .Index(t => t.encargado_id);
            
            CreateTable(
                "public.telecentro",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.ticket",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        estado_ticket_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.estado_ticket", t => t.estado_ticket_id, cascadeDelete: true)
                .Index(t => t.estado_ticket_id);
            
            CreateTable(
                "public.tipo_incidencia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.incidencia", "usuario_id", "public.usuario");
            DropForeignKey("public.incidencia", "tipo_incidencia_id", "public.tipo_incidencia");
            DropForeignKey("public.incidencia", "ticket_id", "public.ticket");
            DropForeignKey("public.ticket", "estado_ticket_id", "public.estado_ticket");
            DropForeignKey("public.incidencia", "telecentro_id", "public.telecentro");
            DropForeignKey("public.incidencia", "equipo_id", "public.equipo");
            DropForeignKey("public.incidencia", "encargado_id", "public.usuario");
            DropForeignKey("public.incidencia", "area_incidencia_id", "public.area_incidencia");
            DropIndex("public.ticket", new[] { "estado_ticket_id" });
            DropIndex("public.incidencia", new[] { "encargado_id" });
            DropIndex("public.incidencia", new[] { "usuario_id" });
            DropIndex("public.incidencia", new[] { "equipo_id" });
            DropIndex("public.incidencia", new[] { "telecentro_id" });
            DropIndex("public.incidencia", new[] { "tipo_incidencia_id" });
            DropIndex("public.incidencia", new[] { "ticket_id" });
            DropIndex("public.incidencia", new[] { "area_incidencia_id" });
            DropTable("public.tipo_incidencia");
            DropTable("public.ticket");
            DropTable("public.telecentro");
            DropTable("public.incidencia");
            DropTable("public.estado_ticket");
            DropTable("public.equipo");
            DropTable("public.area_incidencia");
        }
    }
}
