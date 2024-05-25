using MediaKitWpfApp.Models;
using Microsoft.EntityFrameworkCore;
using Weick.Orm.Core;

namespace MediaKitWpfApp.DbContexts
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
            optionsBuilder.UseSqlite($@"DataSource={System.Environment.CurrentDirectory}\mediakit.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SysParm>()
                .HasIndex(m => new { m.Key, m.Type })
                .IsUnique();

            //modelBuilder.Seed();
        }
    }
}
