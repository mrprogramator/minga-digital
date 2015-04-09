namespace MingaDigital.App.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.usuario", "password_hash", c => c.Binary(nullable: false));
            AddColumn("public.usuario", "password_salt", c => c.Binary(nullable: false));
            AddColumn("public.usuario", "password_algorithm", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.usuario", "password_algorithm");
            DropColumn("public.usuario", "password_salt");
            DropColumn("public.usuario", "password_hash");
        }
    }
}
