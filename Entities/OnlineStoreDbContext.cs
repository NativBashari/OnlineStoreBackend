using Microsoft.EntityFrameworkCore;
using Models.ProductsManagement;

namespace Entities
{
    public class OnlineStoreDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Category> Categories { get; set; }

        public OnlineStoreDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionBuilder)
        {
            OptionBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OnlineStoreDb;Trusted_Connection=True");
        }

    }
}