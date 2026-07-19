namespace MissTortas.Desktop.Model
{
    public class Preparation
    {
        public long Id { get; set; }
        public string Detail { get; set; } = string.Empty;
        public string ClientUsername { get; set; } = string.Empty;
        public bool Done { get; set; }
        public long AssigneeId { get; set; }
        public User Assignee { get; set; } = default!;
        public long OrderId { get; set; }
        public Order Order { get; set; } = default!;
    }
}