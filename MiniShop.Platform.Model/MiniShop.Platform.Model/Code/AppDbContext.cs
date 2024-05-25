using Microsoft.EntityFrameworkCore;
using Weick.Orm.Core;

namespace MiniShop.Platform.Model.Code
{
    public class AppDbContext : BaseDbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RenewPackage>()
                .HasIndex(m => m.Name)
                .IsUnique();

            modelBuilder.Seed();
        }
    }
}
