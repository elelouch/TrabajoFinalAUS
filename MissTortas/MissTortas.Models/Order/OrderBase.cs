using MissTortas.Models.Security.User;

namespace MissTortas.Models.Order
{
    public class OrderBase
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public required OrderType OrderType;
        public required UserBase OrderManager { get; set; }
        public required UserBase Client { get; set; }
        public List<OrderPreparation>? Preparations { get; set; }

    }
}
