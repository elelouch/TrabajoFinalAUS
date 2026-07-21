namespace MissTortas.View.DTO.Orders
{
    public class PatchOrderPreparationRequest
    {
        public string Status { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
        public string AssigneeId { get; set; } = string.Empty;
    }
}