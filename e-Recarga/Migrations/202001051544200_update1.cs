namespace e_Recarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservas", "CustoReserva", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservas", "CustoReserva");
        }
    }
}
