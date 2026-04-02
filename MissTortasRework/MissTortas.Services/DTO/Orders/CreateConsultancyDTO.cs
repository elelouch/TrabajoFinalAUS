namespace MissTortas.Services.DTO.Orders
{
    public class CreateConsultancyDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public required long AssigneeId { get; set; }
        public required long ClientId { get; set; }

    }
}
