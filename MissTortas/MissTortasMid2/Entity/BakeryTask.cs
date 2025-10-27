namespace MissTortasMid2.Entity
{
    public class BakeryTask
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UID { get; set; } = string.Empty;

        public static readonly List<BakeryTask> tasks = [];
        private static int gid = 0; 
        public static int NextID()
        {
            return gid++; 
        }

    }
}
