using Microsoft.EntityFrameworkCore;
using Wirtrack.Domain.Entities;

namespace Wirtrack.AccessData
{
    public class WirtrackContext : DbContext
    {

        public WirtrackContext(DbContextOptions<WirtrackContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seeding();
        }

        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Trips> Trips { get; set; }

    }
}
