using Microsoft.EntityFrameworkCore;
using MissTortasEngine.Model.Order;

namespace MissTortasEngine.Model
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
        public DbSet<MissTortasEngine.Model.Order.OrderType> OrderTypes { get; set; } = default!;
        public DbSet<MissTortasEngine.Model.Security.User.UserBase> Users { get; set; } = default!;
    }
}
