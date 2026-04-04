using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Orders;
using MissTortas.Domain.Payments;
using MissTortas.Domain.Products;
using MissTortas.Domain.Security.Authorization;
using MissTortas.Domain.Security.Users;
using MissTortas.Infrastructure.Entity.Orders;
using MissTortas.Infrastructure.Security.Identity;

namespace MissTortas.Infrastructure.Context
{
    public class MissTortasContext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
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
        public DbSet<PaymentMethodDetail> PaymentMethodDetails { get; set; } = default!;

        public DbSet<Right> Rights { get; set; }
        public DbSet<User> DomainUsers { get; set; }
        public DbSet<Role> DomainRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subject>().UseTptMappingStrategy();
            modelBuilder.Entity<Resource>().UseTptMappingStrategy();

            modelBuilder.Entity<Right>(r =>
            {
                r.HasKey(r => new { r.SubjectId, r.ResourceId });
            });


            modelBuilder.Entity<ApplicationUser>(appUser =>
            {
                appUser.HasOne(e => e.User).WithOne().HasForeignKey<ApplicationUser>(e => e.UserId).HasPrincipalKey<User>(u => u.Id); ;
                appUser.Property(u => u.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Consultancy>(c =>
            {
                c.HasOne(c => c.Assignee).WithMany().OnDelete(DeleteBehavior.NoAction);
                c.HasOne(c => c.Client).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.HasIndex(p => new { p.Name }).IsUnique();
                p.HasOne(p => p.ProductDetail).WithOne(pd => pd.Product).HasForeignKey<Product>(p => p.Id);
                p.HasOne(p => p.ProductCategory).WithMany(pc => pc.Products);
            });

            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Products)
                .WithOne(p => p.ProductCategory);

            modelBuilder.Entity<Order>(o =>
            {
                o.HasMany(o => o.ProductsAsked).WithOne(ps => ps.Order);
                o.HasMany(o => o.Preparations).WithOne(prep => prep.Order).HasForeignKey(prep => prep.Id);
                o.HasOne(o => o.Consultancy).WithMany(c => c.Orders).HasForeignKey(o => o.ConsultancyId);
                o.HasOne(o => o.PaymentRequest).WithOne(pr => pr.Order).HasForeignKey<PaymentRequest>(pr => pr.OrderId);
            });

            modelBuilder.Entity<OrderSaleProduct>().HasIndex(osp => new { osp.OrderId, osp.SaleProductId });

            modelBuilder.Entity<OrderPreparation>()
                .HasOne(op => op.Assignee)
                .WithMany(assignee => assignee.Preparations);

            modelBuilder.Entity<ConsultancyFile>()
                .HasOne(c => c.Consultancy)
                .WithMany();

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
                .HasForeignKey<PaymentMethodDetail>(pmd => pmd.PaymentId);

            modelBuilder.Entity<PaymentRequest>()
                .HasOne(pr => pr.Payment)
                .WithOne(p => p.PaymentRequest)
                .HasForeignKey<Payment>(p => p.PaymentRequestId);

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.HasOne(r => r.Role).WithOne().HasForeignKey<ApplicationRole>(r => r.RoleId).HasPrincipalKey<Role>(r => r.Id);
            });

        }

    }
}
