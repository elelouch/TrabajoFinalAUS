using MissTortas.Data.Entity.Security;
using MissTortas.Data.Entity.Security.User;

namespace MissTortas.Data.Entity.Orders
{
    public class Address
    {
        public int Id { get; set; } = 0;
        public int Number { get; set; } = 0;
        public string Street { get; set; } = string.Empty;
        public virtual required HomeType HomeType { get; set; }
        public virtual required ApplicationUser User { get; set; }
    }
}
