namespace e_Recarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PostoCarregamento", "VelocidadeCarregamento", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PostoCarregamento", "VelocidadeCarregamento", c => c.Int(nullable: false));
        }
    }
}
