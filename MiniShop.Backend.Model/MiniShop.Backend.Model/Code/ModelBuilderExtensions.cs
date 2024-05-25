using Microsoft.EntityFrameworkCore;

namespace MiniShop.Backend.Model.Code
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Shop>().HasData(InitializationData.Initialization.Shop);
        }
    }
}
