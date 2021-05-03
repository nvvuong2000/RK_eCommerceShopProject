using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Models;


namespace RookieShop.Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>().HasKey(sc => new { sc.ProductId, sc.UserId });
            modelBuilder.Entity<ProviderProduct>().HasKey(sc => new { sc.ProductId, sc.ProviderId });
            modelBuilder.Entity<RattingProduct>().HasKey(sc => new { sc.ProductId, sc.UserId, sc.Id });
            modelBuilder.Entity<Provider>().HasData(
               new Provider { Id = 3, ProviderName = "NXB Kim Dong" },
               new Provider { Id = 4, ProviderName = " NXB Tuoi Tre" },
               new Provider { Id = 5, ProviderName = "NXB Giao Duc" },
               new Provider { Id = 6, ProviderName = "NXB Giao Duc" },
               new Provider { Id = 7, ProviderName = "NXB Tong Hop HCM" });
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 3, CategoryName = "Foreign", CategoryDescription = "Foreign language books are original books produced in foreign countries" },
               new Category { Id = 4, CategoryName = "Cookbooks", CategoryDescription = "a book containing recipes and other information about the preparation and cooking of food." },
               new Category { Id = 5, CategoryName = "Comics", CategoryDescription = "causing or meant to cause laughter." });
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<RattingProduct> RattingProduct { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
    }
}
