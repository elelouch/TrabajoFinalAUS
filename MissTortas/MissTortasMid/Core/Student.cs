namespace MissTortasMid.Core
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UID { get; set; } = string.Empty;
        public string Direction { get; set; } = string.Empty;

        public static readonly List<Student> students = [];
        private static int gid = 0;
        public static int NextID()
        {
            return gid++;
        }
    }
}
