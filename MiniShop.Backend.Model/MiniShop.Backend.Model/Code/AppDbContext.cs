using Microsoft.EntityFrameworkCore;
using Weick.Orm.Core;

namespace MiniShop.Backend.Model.Code
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
            modelBuilder.Entity<Shop>()
                .HasIndex(m => new { m.ShopId })
                .IsUnique();
            modelBuilder.Entity<Store>()
                .HasIndex(m => new { m.ShopId, m.StoreId })
                .IsUnique();
            modelBuilder.Entity<Store>()
                .HasIndex(m => new { m.ShopId, m.Name })
                .IsUnique();
            modelBuilder.Entity<Item>()
                .HasIndex(m => new { m.ShopId, m.Code })
                .IsUnique();
            modelBuilder.Entity<Categorie>()
                .HasIndex(m => new { m.ShopId, m.Code })
                .IsUnique();
            modelBuilder.Entity<Unit>()
                .HasIndex(m => new { m.ShopId, m.Code })
                .IsUnique();
            modelBuilder.Entity<Supplier>()
                .HasIndex(m => new { m.ShopId, m.Code })
                .IsUnique();
            modelBuilder.Entity<PurchaseOder>()
                .HasIndex(m => new { m.ShopId, m.OderNo })
                .IsUnique();
            modelBuilder.Entity<PurchaseOderItem>()
                .HasIndex(m => new { m.Id, m.ShopId })
                .IsUnique();
            modelBuilder.Entity<PurchaseReceiveOder>()
                .HasIndex(m => new { m.ShopId, m.OderNo })
                .IsUnique();
            modelBuilder.Entity<PurchaseReceiveOderItem>()
                .HasIndex(m => new { m.Id, m.ShopId })
                .IsUnique();
            modelBuilder.Entity<PurchaseReturnOder>()
                .HasIndex(m => new { m.ShopId, m.OderNo })
                .IsUnique();
            modelBuilder.Entity<PurchaseReturnOderItem>()
                .HasIndex(m => new { m.Id, m.ShopId })
                .IsUnique();
            modelBuilder.Entity<Payment>()
                .HasIndex(m => new { m.ShopId, m.Code })
                .IsUnique();
            modelBuilder.Entity<PosRegister>()
                .HasIndex(m => new { m.Code })
                .IsUnique();
            modelBuilder.Entity<BillInfo>()
                .HasIndex(m => new { m.ShopId, m.BillNo })
                .IsUnique();
            modelBuilder.Entity<PayFlow>()
                .HasIndex(m => new { m.ShopId, m.BillNo })
                .IsUnique();
            modelBuilder.Entity<SaleFlow>()
                .HasIndex(m => new { m.ShopId, m.BillNo })
                .IsUnique();
            modelBuilder.Entity<Stock>()
                .HasIndex(m => new { m.Id, m.ShopId })
                .IsUnique();
            modelBuilder.Entity<Vip>()
                .HasIndex(m => new { m.ShopId, m.Code })
                .IsUnique();
            modelBuilder.Entity<VipType>()
                .HasIndex(m => new { m.ShopId, m.Code })
                .IsUnique();
            modelBuilder.Entity<VipScoreSetting>()
                .HasIndex(m => new { m.Id, m.ShopId })
                .IsUnique();
            modelBuilder.Entity<PromotionOder>()
                .HasIndex(m => new { m.ShopId, m.OderNo })
                .IsUnique();
            modelBuilder.Entity<PromotionDiscountCategorie>()
                .HasIndex(m => new { m.Id, m.ShopId })
                .IsUnique();
            modelBuilder.Entity<PromotionDiscountItem>()
                .HasIndex(m => new { m.Id, m.ShopId })
                .IsUnique();
            modelBuilder.Entity<PromotionSpecialOfferItem>()
                .HasIndex(m => new { m.Id, m.ShopId })
                .IsUnique();
            modelBuilder.Seed();
        }
    }
}
