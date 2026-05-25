namespace MissTortas.Domain.Security.Contacts
{
    public class Contact
    {
        public long ContactId { get; set; } = default!;
        public string Description { get; set; } = string.Empty;
        public DateTime Create { get; set; }
        public required ContactMedia Media { get; set; }
    }
}
