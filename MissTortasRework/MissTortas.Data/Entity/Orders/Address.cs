using MissTortas.Data.Entity.Security;

namespace MissTortas.Data.Entity.Orders
{
    public class Address
    {
        public int Id { get; set; } = 0;
        public int Number { get; set; } = 0;
        public string Street { get; set; } = string.Empty;
        public required HomeType HomeType { get; set; }
        public required User User { get; set; }
    }
}
