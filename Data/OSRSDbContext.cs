using Microsoft.EntityFrameworkCore;
using OSRSHelper.Models;

namespace OSRSHelper.Data
{
    public class OSRSDbContext : DbContext
    {
        public OSRSDbContext(DbContextOptions<OSRSDbContext> options) : base(options)
        {
        }
        public DbSet<FarmType> FarmTypes { get; set; }
        public DbSet<FarmSpot> FarmSpots { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Product> Products { get; set; }

        internal async Task SaveChangesAsync(FarmSpot farmSpotInDb)
        {
            throw new NotImplementedException();
        }
    }
}
