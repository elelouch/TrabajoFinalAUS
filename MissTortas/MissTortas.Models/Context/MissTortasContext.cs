using Microsoft.EntityFrameworkCore;
using MissTortas.Models.Order;
using MissTortas.Models.Security.User;

namespace MissTortas.Models.Context
{
    public class MissTortasContext : DbContext
    {
        public MissTortasContext(DbContextOptions options) : base(options)
        {
        }

        protected MissTortasContext()
        {
        }
        public DbSet<OrderBase> OrderItems { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; } = default!;
        public DbSet<UserBase> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBase>().ToTable("User");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Command Timeout=0");
        }
    }
}
