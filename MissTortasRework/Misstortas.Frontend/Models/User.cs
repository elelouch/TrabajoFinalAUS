namespace Misstortas.Frontend.Models
{
    public class User
    {
        public string UserId { get; set; } = "";
        public string[] Roles { get; set; } = [];
        public bool Enabled { get; set; }
    }
}
