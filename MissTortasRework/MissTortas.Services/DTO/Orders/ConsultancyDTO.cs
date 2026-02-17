namespace MissTortas.Services.DTO.Orders
{
    public class ConsultancyDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public ICollection<string> FilePaths { get; set; } = [];
    }
}
