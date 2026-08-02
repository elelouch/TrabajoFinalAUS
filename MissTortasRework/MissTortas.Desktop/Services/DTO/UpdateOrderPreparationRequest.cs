namespace MissTortas.Desktop.Services.DTO
{
    public class UpdateOrderPreparationRequest
    {
        public string Detail { get; set; } = string.Empty;
        public string AssigneeId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
