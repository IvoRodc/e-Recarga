namespace e_Recarga.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class eRecargaDB : DbContext
    {
        // Your context has been configured to use a 'eRecargaDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'e_Recarga.DAL.eRecargaDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'eRecargaDB' 
        // connection string in the application configuration file.
        public eRecargaDB()
            : base("name=eRecargaDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet <PostoCarregamento> Postos { get; set; }
        public virtual DbSet <Reservas> Reservas { get; set; }
    }
}