using MissTortasEngine.Model.Security.User;

namespace MissTortasEngine.Model.Order
{
    public class Address
    {
        public int Id { get; set; } = 0;
        public int Number { get; set; } = 0;
        public string Street { get; set; } = string.Empty;
        public required HomeType HomeType { get; set; }
        public User User { get; set; }
        public Address() { }
        
    }
}
