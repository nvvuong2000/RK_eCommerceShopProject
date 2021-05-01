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
               new Provider { Id = 3, ProviderName = "H&M" },
               new Provider { Id = 4, ProviderName = "B&G" });
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 3, CategoryName = "Jacket", CategoryDescription= "A jacket is a garment for the upper body, usually extending below the hips. .." },
               new Category { Id = 4, CategoryName = "Pant" , CategoryDescription = "pants (North American English) are an item of clothing that might have originated in Central Asia, worn from the waist to the ankles, covering ..." });
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
