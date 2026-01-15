using Microsoft.EntityFrameworkCore;
using MissTortas.Models.Model.Order;

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
        public DbSet<MissTortas.Models.Model.Order.OrderType> OrderTypes { get; set; } = default!;
        public DbSet<MissTortas.Models.Model.Security.User.UserBase> Users { get; set; } = default!;
    }
}
