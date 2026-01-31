namespace MissTortas.Engine.DTO.Order
{
    public class OrderRegistrationDTO
    {
        public string Description { get; set; } = string.Empty;
        public required long OrderType;
        public required long OrderManager { get; set; }
        public required long Client { get; set; }
    }
}
