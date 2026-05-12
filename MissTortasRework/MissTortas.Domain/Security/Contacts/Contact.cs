using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Security.Contacts
{
    public class Contact : IHasResource
    {
        public long ContactId { get; set; } = default!;
        public long ResourceId { get; set; }
        public Resource Resource { get; set; } = default!;
        public string Description { get; set; } = string.Empty;
        public DateTime Create { get; set; }
        public required ContactMedia Media { get; set; }
    }
}
