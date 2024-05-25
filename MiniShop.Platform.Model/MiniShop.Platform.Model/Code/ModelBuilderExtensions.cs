using Microsoft.EntityFrameworkCore;

namespace MiniShop.Platform.Model.Code
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RenewPackage>().HasData(InitializationData.Initialization.RenewPackage);
        }
    }
}
