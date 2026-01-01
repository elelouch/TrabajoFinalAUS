namespace MissTortasEngine.Model.Security
{
    public class Role
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public DateTime LastTimeModified { get; set; }
        public bool Deleted { get; set; }
    }
}
