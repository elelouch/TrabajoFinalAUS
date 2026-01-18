using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Entity.Orders;
using MissTortas.Data.Entity.Security;

namespace MissTortas.Data.Context
{
    public class MissTortasContext : DbContext
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MissTortasDevelopment;Integrated Security=True;Multiple Active Result Sets=True");
        }
    }
}
