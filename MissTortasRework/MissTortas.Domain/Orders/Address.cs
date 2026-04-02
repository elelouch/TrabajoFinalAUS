using MissTortas.Domain.Security.Contacts;
using MissTortas.Domain.Security.Users;

namespace MissTortas.Domain.Orders
{
    public class Address
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public string Street { get; set; } = string.Empty;
        public virtual required HomeType HomeType { get; set; }
        public virtual required User User { get; set; }
    }
}
