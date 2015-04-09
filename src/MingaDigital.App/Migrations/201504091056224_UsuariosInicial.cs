namespace MingaDigital.App.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuariosInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.accion",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.permiso_global",
                c => new
                    {
                        accion_id = c.String(nullable: false, maxLength: 128),
                        usuario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.accion_id, t.usuario_id })
                .ForeignKey("public.accion", t => t.accion_id, cascadeDelete: true)
                .ForeignKey("public.usuario", t => t.usuario_id, cascadeDelete: true)
                .Index(t => t.accion_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "public.rol",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.usuario", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "public.permiso_rol",
                c => new
                    {
                        accion_id = c.String(nullable: false, maxLength: 128),
                        rol_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.accion_id, t.rol_id })
                .ForeignKey("public.accion", t => t.accion_id, cascadeDelete: true)
                .ForeignKey("public.rol", t => t.rol_id, cascadeDelete: true)
                .Index(t => t.accion_id)
                .Index(t => t.rol_id);
            
            CreateTable(
                "public.usuario_rol",
                c => new
                    {
                        usuario_id = c.Int(nullable: false),
                        rol_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.usuario_id, t.rol_id })
                .ForeignKey("public.rol", t => t.rol_id, cascadeDelete: true)
                .ForeignKey("public.usuario", t => t.usuario_id, cascadeDelete: true)
                .Index(t => t.usuario_id)
                .Index(t => t.rol_id);
            
            AddColumn("public.usuario", "username", c => c.String());
            CreateIndex("public.usuario", "username", unique: true);
        }
        
        public override void Down()
        {
            DropForeignKey("public.usuario_rol", "usuario_id", "public.usuario");
            DropForeignKey("public.usuario_rol", "rol_id", "public.rol");
            DropForeignKey("public.permiso_rol", "rol_id", "public.rol");
            DropForeignKey("public.permiso_rol", "accion_id", "public.accion");
            DropForeignKey("public.rol", "Usuario_Id", "public.usuario");
            DropForeignKey("public.permiso_global", "usuario_id", "public.usuario");
            DropForeignKey("public.permiso_global", "accion_id", "public.accion");
            DropIndex("public.usuario_rol", new[] { "rol_id" });
            DropIndex("public.usuario_rol", new[] { "usuario_id" });
            DropIndex("public.permiso_rol", new[] { "rol_id" });
            DropIndex("public.permiso_rol", new[] { "accion_id" });
            DropIndex("public.rol", new[] { "Usuario_Id" });
            DropIndex("public.permiso_global", new[] { "usuario_id" });
            DropIndex("public.permiso_global", new[] { "accion_id" });
            DropIndex("public.usuario", new[] { "username" });
            DropColumn("public.usuario", "username");
            DropTable("public.usuario_rol");
            DropTable("public.permiso_rol");
            DropTable("public.rol");
            DropTable("public.permiso_global");
            DropTable("public.accion");
        }
    }
}
