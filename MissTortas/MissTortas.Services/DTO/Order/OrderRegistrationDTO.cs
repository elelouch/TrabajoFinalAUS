using MissTortasEngine.Model.Security.User;

namespace MissTortasEngine.Model.Order
{
    public class OrderRegistrationDTO
    {
        public string Description { get; set; } = string.Empty;
        public required long OrderType;
        public required long OrderManager { get; set; }
        public required long Client { get; set; }
    }
}
