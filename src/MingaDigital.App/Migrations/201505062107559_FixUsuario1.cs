namespace MingaDigital.App.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixUsuario1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.usuario_persona_fisica",
                c => new
                    {
                        usuario_id = c.Int(nullable: false),
                        persona_fisica_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.usuario_id)
                .ForeignKey("public.usuario", t => t.usuario_id)
                .ForeignKey("public.persona_fisica", t => t.persona_fisica_id, cascadeDelete: true)
                .Index(t => t.usuario_id)
                .Index(t => t.persona_fisica_id);
            
            CreateTable(
                "public.usuario_persona_juridica",
                c => new
                    {
                        usuario_id = c.Int(nullable: false),
                        persona_juridica_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.usuario_id)
                .ForeignKey("public.usuario", t => t.usuario_id)
                .ForeignKey("public.persona_juridica", t => t.persona_juridica_id, cascadeDelete: true)
                .Index(t => t.usuario_id)
                .Index(t => t.persona_juridica_id);
        }
        
        public override void Down()
        {
            DropForeignKey("public.usuario_persona_juridica", "persona_juridica_id", "public.persona_juridica");
            DropForeignKey("public.usuario_persona_juridica", "usuario_id", "public.usuario");
            DropForeignKey("public.usuario_persona_fisica", "persona_fisica_id", "public.persona_fisica");
            DropForeignKey("public.usuario_persona_fisica", "usuario_id", "public.usuario");
            DropIndex("public.usuario_persona_juridica", new[] { "persona_juridica_id" });
            DropIndex("public.usuario_persona_juridica", new[] { "usuario_id" });
            DropIndex("public.usuario_persona_fisica", new[] { "persona_fisica_id" });
            DropIndex("public.usuario_persona_fisica", new[] { "usuario_id" });
            DropTable("public.usuario_persona_juridica");
            DropTable("public.usuario_persona_fisica");
        }
    }
}
