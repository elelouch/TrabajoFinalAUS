namespace MissTortas.Data.Entity.Orders
{
    public class ConsultancyFile
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Extension { get; set; } = string.Empty;
        public required Consultancy Consultancy { get; set; }
        public string Path { get; set; } = string.Empty;
    }
}
