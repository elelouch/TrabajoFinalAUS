using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Payment;
using MissTortas.Data.Entity.Products;
using MissTortas.Data.Entity.Security.Permissions;
using MissTortas.Data.Entity.Security.User;

namespace MissTortas.Data.Context
{
    public class MissTortasContext(DbContextOptions options) : IdentityDbContext<ApplicationUser, ApplicationRole, long, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>(options)
    {
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<ProductDetail> ProductDetails { get; set; } = default!;
        public DbSet<SaleProduct> SaleProducts { get; set; } = default!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = default!;
        public DbSet<ProductFile> ProductFiles { get; set; } = default!;
        public DbSet<OrderSaleProduct> AskedProducts { get; set; } = default!;

        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderType> OrderTypes { get; set; } = default!;
        public DbSet<Consultancy> Consultancies { get; set; } = default!;
        public DbSet<OrderPreparation> OrderPreparations { get; set; } = default!;
        public DbSet<ConsultancyFile> ConsultancyFiles { get; set; } = default!;

        public DbSet<Payment> Payments { get; set; } = default!;
        public DbSet<PaymentRequest> PaymentRequests { get; set; } = default!;
        public DbSet<PaymentMethodDetailBase> PaymentMethodDetails { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(appUser =>
            {
                appUser.HasIndex(u => new { u.Email, u.UserName });
                appUser.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                appUser.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                appUser.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                appUser.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<Consultancy>()
                .HasOne(c => c.Assignee)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Consultancy>()
                .HasOne(c => c.Client)
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

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Consultancy)
                .WithMany(c => c.Orders);

            modelBuilder.Entity<OrderSaleProduct>()
                .HasKey(osp => new { osp.OrderId, osp.SaleProductId });

            modelBuilder.Entity<SaleProduct>()
                .HasOne(sp => sp.StockProduct)
                .WithOne(p => p.SaleProduct)
                .HasForeignKey<SaleProduct>("StockProductId");

            modelBuilder.Entity<OrderPreparation>()
                .HasOne(op => op.Assignee)
                .WithMany(assignee => assignee.Preparations);

            modelBuilder.Entity<Consultancy>()
                .HasMany(c => c.ConsultancyFiles)
                .WithOne(pp => pp.Consultancy);

            modelBuilder.Entity<Consultancy>()
                .HasMany(c => c.ConsultancyFiles)
                .WithOne(cf => cf.Consultancy);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Consultancy)
                .WithMany(c => c.Orders);

            var cc = modelBuilder.Entity<CreditCardDetail>();
            cc.Property(cc => cc.PAN).HasColumnName("PAN");
            cc.Property(cc => cc.ExpirationDate).HasColumnName("ExpirationDate");
            cc.Property(cc => cc.CardHolderName).HasColumnName("CardHolderName");

            var dc = modelBuilder.Entity<DebitCardDetail>();
            dc.Property(dc => dc.PAN).HasColumnName("PAN");
            dc.Property(dc => dc.ExpirationDate).HasColumnName("ExpirationDate");
            dc.Property(dc => dc.CardHolderName).HasColumnName("CardHolderName");

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.PaymentMethodDetail)
                .WithOne(pmd => pmd.Payment)
                .HasForeignKey<PaymentMethodDetailBase>(pmd => pmd.PaymentId);

            modelBuilder.Entity<PaymentRequest>()
                .HasOne(pr => pr.Payment)
                .WithOne(p => p.PaymentRequest)
                .HasForeignKey<Payment>(p => p.PaymentRequestId);

            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.RoleId, ur.UserId });
                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                userRole.ToTable(name:"ApplicationUserRole");
            });

            modelBuilder.Entity<ApplicationRoleClaim>().ToTable(name: "ApplicationRoleClaim");

            modelBuilder.Entity<ApplicationUserClaim>().ToTable(name:"ApplicationUserClaim");

            modelBuilder.Entity<ApplicationUserLogin>(aul =>
            {
                aul.ToTable(name: "ApplicationUserLogin");
            });

            modelBuilder.Entity<ApplicationUser>().ToTable(name: "ApplicationUser");

            modelBuilder.Entity<ApplicationUserToken>().ToTable(name: "ApplicationUserToken");

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
                b.ToTable(name: "ApplicationRole");
            });

        }

    }
}
