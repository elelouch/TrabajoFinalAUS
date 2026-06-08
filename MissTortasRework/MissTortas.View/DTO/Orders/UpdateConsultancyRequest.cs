namespace MissTortas.View.DTO.Orders
{
    public class UpdateConsultancyRequest
    {
        public int NewStatus { get; set; }
        public string BakeryNotes { get; set; } = string.Empty;
    }
}
