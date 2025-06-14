using Microsoft.EntityFrameworkCore;

namespace bc.Models.DbModels
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
       : base(options)
        {
        }

        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Skladnik> Skladniki { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<ProduktZamowienie> ProduktyZamowienia { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kategoria>().HasData(
                new Kategoria { IdKategorii = 1, Name = "Kawa" },
                new Kategoria { IdKategorii = 2, Name = "Herbata" },
                new Kategoria { IdKategorii = 3, Name = "Desery" }
            );

            modelBuilder.Entity<Produkt>().HasData(
                new Produkt { IdProduktu = 1, NazwaProduktu = "Espresso", IdKategorii = 1 },
                new Produkt { IdProduktu = 2, NazwaProduktu = "Cappuccino", IdKategorii = 1 },
                new Produkt { IdProduktu = 3, NazwaProduktu = "Zielona herbata", IdKategorii = 2 }
            );

            modelBuilder.Entity<Skladnik>().HasData(
                new Skladnik { IdSkladnika = 1, NazwaSkladnika = "Mleko" },
                new Skladnik { IdSkladnika = 2, NazwaSkladnika = "Cukier" },
                new Skladnik { IdSkladnika = 3, NazwaSkladnika = "Cytryna" }
            );
            modelBuilder.Entity<Zamowienie>().HasData(
                new Zamowienie
                {
                    IdZamowienia = 1,
                    DataZamowienia = DateTime.Now,
                    KwotaZamowienia = 15.99m,
                    StatusZamowienia = Status.przygotowywany
                },
                 new Zamowienie
                 {
                     IdZamowienia = 2,
                     DataZamowienia = DateTime.Now,
                     KwotaZamowienia = 25.50m,
                     StatusZamowienia = Status.gotowy
                 }
                 );

            modelBuilder.Entity<ProduktZamowienie>().HasData(
                new ProduktZamowienie { PzId = 1, ProduktId = 1, ZamowienieId = 1, Ilosc = 2 },
                new ProduktZamowienie { PzId = 2, ProduktId = 2, ZamowienieId = 2, Ilosc = 1 }
            );
        }
    }

}
