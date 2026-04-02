using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Security.Contacts
{
    public class Contact : Resource
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Create { get; set; }
        public required ContactMedia Media { get; set; }
    }
}
