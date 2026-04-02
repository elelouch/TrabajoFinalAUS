namespace MissTortas.Services.DTO.Orders
{
    public class ConsultancyDTO
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int StatusId { get; set; }
    }
}
