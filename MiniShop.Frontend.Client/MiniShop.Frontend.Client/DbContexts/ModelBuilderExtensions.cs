using Microsoft.EntityFrameworkCore;

namespace MiniShop.Frontend.Client.DbContexts
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Shop>().HasData(InitializationData.Initialization.Shop);
        }
    }
}
