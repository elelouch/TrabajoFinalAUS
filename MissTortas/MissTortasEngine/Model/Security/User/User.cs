namespace MissTortasEngine.Model.Security.User
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; } = false;
        public List<Role>? Roles { get; set; }
    }
}
