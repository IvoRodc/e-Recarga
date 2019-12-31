namespace e_Recarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PostoCarregamento", newName: "PostoCarregamento");
            AlterColumn("dbo.PostoCarregamento", "Id_OPC", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Reservas", "id_Cliente", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservas", "id_Cliente", c => c.Int(nullable: false));
            AlterColumn("dbo.PostoCarregamento", "Id_OPC", c => c.Int(nullable: false));
            RenameTable(name: "dbo.PostoCarregamento", newName: "PostoCarregamento");
        }
    }
}
