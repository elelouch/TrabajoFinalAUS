namespace MissTortas.Presentation.DTO.Orders
{
    public class UpdateConsultancy
    {
        public long Id { get; set; }
        public int NewStatus { get; set; }
        public string BakeryNotes { get; set; } = string.Empty;
    }
}
