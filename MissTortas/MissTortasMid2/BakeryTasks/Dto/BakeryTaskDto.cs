using System.ComponentModel.DataAnnotations;

namespace MissTortasMid2.BakeryTasks.Dto
{
    public class BakeryTaskDto
    {
        [Required]
        [StringLength(255, MinimumLength=3)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;
    }
}
