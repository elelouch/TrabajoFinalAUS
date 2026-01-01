using Microsoft.EntityFrameworkCore;

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
        public DbSet<>
    }
}
