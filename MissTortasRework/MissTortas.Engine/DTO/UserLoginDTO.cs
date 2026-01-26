namespace MissTortas.Services.DTO
{
    public class UserLoginDTO
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty; 
    }
}
