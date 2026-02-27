namespace MissTortas.Presentation.DTO.Orders
{
    public class CreateConsultancyDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long ClientId { get; set; }
        public long AssigneeId { get; set; }
    }
}
