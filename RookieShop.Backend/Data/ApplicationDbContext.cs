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
            modelBuilder.Entity<OrderDetails>()
                .HasOne<Order>(o => o.Order)
                .WithMany(od => od.OrderDetails)
                .HasForeignKey(od => od.orderdetailsID);
            modelBuilder.Entity<ProductImages>()
               .HasOne<Product>(p => p.Product)
               .WithMany(pi => pi.ProductImages)
               .HasForeignKey(pi => pi.ProductID);
            modelBuilder.Entity<Product>()
             .HasOne<Category>(ca => ca.Category)
             .WithMany(p => p.Products)
             .HasForeignKey(ca => ca.categoryID);

            modelBuilder.Entity<Order>()
               .HasKey(o => o.orderID);
            modelBuilder.Entity<Order>()

               .HasOne<User>(o => o.User)
               .WithMany(c => c.Orders)
               .HasForeignKey(c => c.userID).IsRequired();
            modelBuilder.Entity<User>()
                .HasOne<Cart>(c => c.Cart)
                .WithOne(ca => ca.User)
                .HasForeignKey<Cart>(ca => ca.userID).IsRequired();
            modelBuilder.Entity<ProviderProduct>().HasKey(sc => new { sc.productID, sc.providerID });
            modelBuilder.Entity<RattingProduct>().HasKey(sc => new { sc.productID, sc.userID, sc.RattingProductID });

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
