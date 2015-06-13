namespace MingaDigital.App.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hola : DbMigration
    {
        public override void Up()
        {
            DropColumn("public.componente", "componente_id");
        }
        
        public override void Down()
        {
            AddColumn("public.componente", "componente_id", c => c.Int(nullable: false));
        }
    }
}
