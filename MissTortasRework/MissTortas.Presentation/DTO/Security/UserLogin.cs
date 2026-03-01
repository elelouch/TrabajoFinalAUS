namespace MissTortas.Presentation.DTO.Security
{
    public class UserLogin
    {
        public long Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty; 
    }
}
