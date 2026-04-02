namespace MissTortas.Services.DTO.Orders
{
    public class OrderPreparationDTO
    {
        public long Id { get; set; }
        public string Detail { get; set; } = string.Empty;
        public bool Done { get; set; }
    }
}
