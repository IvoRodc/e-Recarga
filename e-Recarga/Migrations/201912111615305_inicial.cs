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
                        Id_OPC = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 9),
                        VelocidadeCarregamento = c.Int(nullable: false),
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
                        id_Cliente = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        HoraInicioCarregamento = c.Int(nullable: false),
                        HoraFimCarregamento = c.Int(nullable: false),
                        PostoCarregamento_Id_PostoCarregamento = c.Int(),
                    })
                .PrimaryKey(t => t.id_Reserva)
                .ForeignKey("dbo.PostoCarregamento", t => t.PostoCarregamento_Id_PostoCarregamento)
                .Index(t => t.PostoCarregamento_Id_PostoCarregamento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservas", "PostoCarregamento_Id_PostoCarregamento", "dbo.PostoCarregamento");
            DropIndex("dbo.Reservas", new[] { "PostoCarregamento_Id_PostoCarregamento" });
            DropTable("dbo.Reservas");
            DropTable("dbo.PostoCarregamento");
        }
    }
}
