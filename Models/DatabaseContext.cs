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

    }

}
