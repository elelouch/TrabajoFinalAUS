using Microsoft.EntityFrameworkCore;
using MissTortasEngine.Models;

namespace MissTortasEngine.Data
{
    public class EngineContext(DbContextOptions<EngineContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = null!;
    }
}
