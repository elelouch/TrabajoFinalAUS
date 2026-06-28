namespace MissTortas.View.DTO.Security
{
    public class ModifyApplicationRole
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Permissions { get; set; } = [];
    }
}
