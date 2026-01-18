namespace MissTortas.Data.Entity.Security
{
    public class Contact
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Create { get; set; }
        public required ContactMedia Media { get; set; }
    }
}
