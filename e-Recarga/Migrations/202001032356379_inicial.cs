namespace e_Recarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostoCarregamento",
                c => new
                    {
                        Id_PostoCarregamento = c.Int(nullable: false, identity: true),
                        Id_OPC = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(nullable: false, maxLength: 9),
                        VelocidadeCarregamento = c.Double(nullable: false),
                        NumTomadas = c.Int(nullable: false),
                        Municipio = c.String(nullable: false, maxLength: 20),
                        Localizacao = c.String(nullable: false, maxLength: 200),
                        ValorFixoInicial = c.Double(nullable: false),
                        ValorVariavelTempoMenos30Min = c.Double(nullable: false),
                        ValorVariavelTempoMais30Min = c.Double(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id_PostoCarregamento);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        id_Reserva = c.Int(nullable: false, identity: true),
                        id_Cliente = c.String(nullable: false, maxLength: 128),
                        id_Posto = c.Int(nullable: false),
                        InicioCarregamento = c.DateTime(nullable: false),
                        FimCarregamento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_Reserva)
                .ForeignKey("dbo.PostoCarregamento", t => t.id_Posto, cascadeDelete: true)
                .Index(t => t.id_Posto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservas", "id_Posto", "dbo.PostoCarregamento");
            DropIndex("dbo.Reservas", new[] { "id_Posto" });
            DropTable("dbo.Reservas");
            DropTable("dbo.PostoCarregamento");
        }
    }
}
