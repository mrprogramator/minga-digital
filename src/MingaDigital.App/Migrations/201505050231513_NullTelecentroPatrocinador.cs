namespace MingaDigital.App.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullTelecentroPatrocinador : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.telecentro", "patrocinador_id", "public.persona_juridica");
            DropIndex("public.telecentro", new[] { "patrocinador_id" });
            AlterColumn("public.telecentro", "patrocinador_id", c => c.Int());
            CreateIndex("public.telecentro", "patrocinador_id");
            AddForeignKey("public.telecentro", "patrocinador_id", "public.persona_juridica", "persona_juridica_id");
        }
        
        public override void Down()
        {
            DropForeignKey("public.telecentro", "patrocinador_id", "public.persona_juridica");
            DropIndex("public.telecentro", new[] { "patrocinador_id" });
            AlterColumn("public.telecentro", "patrocinador_id", c => c.Int(nullable: false));
            CreateIndex("public.telecentro", "patrocinador_id");
            AddForeignKey("public.telecentro", "patrocinador_id", "public.persona_juridica", "persona_juridica_id", cascadeDelete: true);
        }
    }
}
