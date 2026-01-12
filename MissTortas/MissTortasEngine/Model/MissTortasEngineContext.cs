using Microsoft.EntityFrameworkCore;
using MissTortasEngine.Model.Order;

namespace MissTortasEngine.Model
{
    public class MissTortasEngineContext : DbContext
    {
        public MissTortasEngineContext(DbContextOptions options) : base(options)
        {
        }

        protected MissTortasEngineContext()
        {
        }
        public DbSet<OrderDTO> OrderItems { get; set; }
        public DbSet<MissTortasEngine.Model.Order.OrderType> OrderTypes { get; set; } = default!;
        public DbSet<MissTortasEngine.Model.Security.User.UserBase> Users { get; set; } = default!;
    }
}
