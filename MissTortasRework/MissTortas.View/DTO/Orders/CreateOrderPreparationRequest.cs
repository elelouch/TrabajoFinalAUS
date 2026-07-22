namespace MissTortas.View.DTO.Orders
{
    public class CreateOrderPreparationRequest
    {
        public long OrderId { get; set; }
        public string Detail { get; set; } = string.Empty;
        public string AssigneeId { get; set; } = string.Empty;
    }
}