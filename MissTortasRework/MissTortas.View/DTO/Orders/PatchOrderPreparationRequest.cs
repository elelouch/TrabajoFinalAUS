namespace MissTortas.View.DTO.Orders
{
    public class PatchOrderPreparationRequest
    {
        public string Status { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
        public long AssigneeId { get; set; }
    }
}