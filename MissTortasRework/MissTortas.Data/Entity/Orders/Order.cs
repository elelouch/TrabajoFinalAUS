using MissTortas.Data.Entity.Security;

namespace MissTortas.Data.Entity.Orders
{
    public class Order
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public required OrderType OrderType;
        public required User OrderManager { get; set; }
        public required User Client { get; set; }
        public required List<OrderPreparation> Preparations { get; set; }

    }
}
