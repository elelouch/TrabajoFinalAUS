namespace MissTortas.Models.Order
{
    public class OrderPreparation
    {
        public long Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public required OrderBase Order { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime FinalizationTime { get; set; }
    }
}
