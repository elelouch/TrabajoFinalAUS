namespace MissTortas.Services.DTO.Security
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDay { get; set; }
    }
}
