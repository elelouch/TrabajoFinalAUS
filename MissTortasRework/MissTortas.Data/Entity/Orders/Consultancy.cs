namespace MissTortas.Data.Entity.Orders
{
    public class Consultancy
    {
        public long Id { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime EstimatedFinishedTime { get; set; }
        public DateTime AlternativeEstimatedFinishedTime { get; set; }
        public virtual ConsultancyStatus Status { get; set; }
        public virtual required Order Order { get; set; }
    }
}
