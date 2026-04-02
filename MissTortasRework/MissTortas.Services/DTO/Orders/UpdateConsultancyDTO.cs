namespace MissTortas.Services.DTO.Orders
{
    public class UpdateConsultancyDTO
    {
        public long ConsultancyId { get; set; }
        public string BakeryNotes { get; set; } = string.Empty;
        public int Status { get; set; }
    }
}
