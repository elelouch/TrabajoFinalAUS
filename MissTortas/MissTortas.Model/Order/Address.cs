using MissTortas.Models.Security.User;

namespace MissTortas.Models.Order
{
    public class Address
    {
        public int Id { get; set; } = 0;
        public int Number { get; set; } = 0;
        public string Street { get; set; } = string.Empty;
        public required HomeType HomeType { get; set; }
        public UserBase User { get; set; }
        public Address() { }
        
    }
}
