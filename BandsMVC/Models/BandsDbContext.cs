using Microsoft.EntityFrameworkCore;

namespace BandsMVC.Models
{
    public class BandsDbContext: DbContext
    {
        public BandsDbContext() : this(false) { }
        public BandsDbContext(bool bFromScratch) : base()
        {
            if (bFromScratch)
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        public BandsDbContext(DbContextOptions<BandsDbContext> options)
        : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder

               .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BandsDB;Trusted_connection=TRUE");
            }
        }
        
        public DbSet<Band> Bands { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }

    }
}
