namespace MissTortas.Data.Entity.Orders
{
    public class Consultancy
    {
        public int Id { get; set; }
        public float FinalPrice {  get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime EstimatedFinishedTime { get; set; }
        public DateTime AlternativeEstimatedFinishedTime { get; set; }
        public ConsultancyStatus Status { get; set; }
        public required Order Order { get; set; }
    }
}
