using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Security;

namespace MissTortas.Data.Context
{
    public class MissTortasContext (DbContextOptions options) : DbContext (options)
    {
        public DbSet<Order> OrderItems { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
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
        }
    }
}
