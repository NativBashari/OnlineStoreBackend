using Microsoft.EntityFrameworkCore;
using Models.ProductsManagement;
using Models.UserManagement;

namespace Entities
{
    public class OnlineStoreDbContext: DbContext
    {
        //PRODUCTS MANAGEMENT
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Category> Categories { get; set; }

        //USERS MANAGEMENT
        public DbSet<User> Users { get; set; }
        public DbSet<UserAdress> UserAdresses { get; set; }
        public DbSet<UserCart> UserCarts { get; set; }

        public OnlineStoreDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionBuilder)
        {
            OptionBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OnlineStoreDb;Trusted_Connection=True");
            OptionBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCart>()
                .HasMany(uc => uc.Products)
                .WithMany(p => p.UserCarts);
            
        }
    }
}