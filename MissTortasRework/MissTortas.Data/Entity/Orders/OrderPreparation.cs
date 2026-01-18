namespace MissTortas.Data.Entity.Orders
{
    public class OrderPreparation
    {
        public long Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public required Order Order { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime FinalizationTime { get; set; }
    }
}
