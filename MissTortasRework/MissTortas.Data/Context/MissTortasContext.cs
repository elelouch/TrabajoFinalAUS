using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Products;
using MissTortas.Data.Entity.Security;

namespace MissTortas.Data.Context
{
    public class MissTortasContext (DbContextOptions options) : IdentityDbContext<ApplicationUser, ApplicationRole, long>(options)
    {
        public DbSet<Order> OrderItems { get; set; } = default!;
        public DbSet<OrderType> OrderTypes { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<ProductDetail> ProductDetails { get; set; } = default!;
        public DbSet<SaleProduct> SaleProducts { get; set; } = default!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = default!;
        public DbSet<Consultancy> Consultancies { get; set; } = default!;
        public DbSet<OrderSaleProduct> AskedProducts { get; set; } = default!;
        public DbSet<OrderPreparation> OrderPreparations { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().HasIndex(u => new {u.Email, u.UserName});
            modelBuilder.Entity<Order>()
                .HasOne(order => order.Client)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>()
                .HasOne(order => order.OrderManager)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>().HasIndex(p => new { p.Name }).IsUnique();

            modelBuilder.Entity<Product>().HasOne(p => p.ProductDetail)
                .WithOne(pd => pd.Product)
                .HasForeignKey<Product>(p => p.Id);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Products)
                .WithOne(p => p.ProductCategory);

            modelBuilder.Entity<Product>().HasOne(p => p.ProductCategory)
                .WithMany(pc => pc.Products);

            modelBuilder.Entity<Order>().HasMany(o => o.ProductsAsked)
                .WithOne(ps => ps.Order);

            modelBuilder.Entity<Order>().HasMany(o => o.Preparations)
                .WithOne(prep => prep.Order)
                .HasForeignKey(prep => prep.Id);

            modelBuilder.Entity<Order>().HasOne(o => o.Consultancy)
                .WithOne(c => c.Order)
                .HasForeignKey<Consultancy>(c => c.Id);

            modelBuilder.Entity<OrderSaleProduct>()
                .HasKey(osp => new { osp.OrderId, osp.SaleProductId });

            modelBuilder.Entity<SaleProduct>()
                .HasOne(sp => sp.StockProduct)
                .WithOne(p => p.SaleProduct)
                .HasForeignKey<SaleProduct>("StockProductId");

            modelBuilder.Entity<OrderPreparation>()
                .HasOne(op => op.Assignee)
                .WithMany(assignee => assignee.Preparations);
        }

        // In your DbContext
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Remove<TableNameFromDbSetConvention>();
        }

    }
}
