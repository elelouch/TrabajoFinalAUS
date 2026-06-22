namespace MissTortas.Infrastructure.DTO.Security
{
    public class ApplicationUserModificationDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public bool? IsEnabled { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? NewPassword { get; set; }
        public IEnumerable<string>? Roles { get; set; }
    }
}
