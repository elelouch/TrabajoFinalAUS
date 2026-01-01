namespace MissTortasEngine.Model.Order
{
    public class OrderPreparation
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public required Order Order { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime FinalizationTime { get; set; }
    }
}
