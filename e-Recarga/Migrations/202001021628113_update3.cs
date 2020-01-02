namespace e_Recarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservas", "InicioCarregamento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservas", "FimCarregamento", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservas", "Data");
            DropColumn("dbo.Reservas", "HoraInicioCarregamento");
            DropColumn("dbo.Reservas", "HoraFimCarregamento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservas", "HoraFimCarregamento", c => c.Int(nullable: false));
            AddColumn("dbo.Reservas", "HoraInicioCarregamento", c => c.Int(nullable: false));
            AddColumn("dbo.Reservas", "Data", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservas", "FimCarregamento");
            DropColumn("dbo.Reservas", "InicioCarregamento");
        }
    }
}
