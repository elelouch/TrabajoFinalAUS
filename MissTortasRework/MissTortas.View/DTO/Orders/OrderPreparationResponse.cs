namespace MissTortas.View.DTO.Orders
{
    public class OrderPreparationResponse
    {
        public long Id { get; set; }
        public string Detail { get; set; } = string.Empty;
        public bool Done { get; set; }
        public long AssigneeId { get; set; }
        public long OrderId { get; set; }
    }
}
