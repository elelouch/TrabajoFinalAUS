using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MissTortas.Data.Entity.Products;

namespace MissTortas.Data.Context
{
    public class MissTortasContext (DbContextOptions options) : IdentityDbContext<ApplicationUser, ApplicationRole, long>(options)
    {
        public DbSet<Order> OrderItems { get; set; } = default!;
        public DbSet<OrderType> OrderTypes { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<ProductDetail> ProductDetails { get; set; } = default!;
        public DbSet<SaleProduct> SaleProducts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("User").HasIndex(u => new {u.Email, u.UserName});
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Order>()
                .HasOne(order => order.Client)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>()
                .HasOne(order => order.OrderManager)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrderType>().ToTable("OrderType");

            modelBuilder.Entity<Product>().ToTable("Product").HasIndex(p => new { p.Name }).IsUnique();

            modelBuilder.Entity<Product>().HasOne(p => p.ProductDetail)
                .WithOne(pd => pd.Product)
                .HasForeignKey<Product>(p => p.Id);

            modelBuilder.Entity<ProductDetail>().ToTable("ProductDetail");
            
            modelBuilder.Entity<ProductDetail>().ToTable("ProductDetail");
        }
    }
}
