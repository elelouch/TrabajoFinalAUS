using MissTortasEngine.Model.Security.User;

namespace MissTortasEngine.Model.Order
{
    public class Order
    {
        public string Description { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; }
        public required OrderType OrderType;
        public required User OrderManager { get; set; }
        public required User Client { get; set; }
        public List<OrderPreparation>? Preparations { get; set; }

    }
}
