namespace Misstortas.Frontend.Models
{
    public class OrderPreparation
    {
        public long Id { get; set; }
        public string Detail { get; set; } = string.Empty;
        public string ClientUsername { get; set; } = string.Empty;
        public bool Done { get; set; }
        public string AssigneeId { get; set; } = string.Empty;
        public long OrderId { get; set; }
    }
}