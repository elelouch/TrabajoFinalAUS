namespace MissTortas.Services.DTO.Security
{
    public class UpdateUserDTO
    {
        public long UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<string> Roles { get; set; } = [];
    }
}
