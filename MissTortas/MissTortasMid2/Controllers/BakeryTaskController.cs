using Microsoft.AspNetCore.Mvc;
using MissTortasMid2.Entity;
using MissTortasMid2.Entity.Dto;

namespace MissTortasMid2.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class BakeryTaskController: Controller
    {
        [HttpGet]
        public List<BakeryTask> GetTasks()
        {
            return BakeryTask.tasks;
        }

        [HttpPost]
        public BakeryTask PostTask(BakeryTaskDto dto)
        {
            var task = new BakeryTask { 
                Description = dto.Description,
                Id = BakeryTask.NextID(),
                Name = dto.Name,
                UID = Guid.NewGuid().ToString(),
            };
            return task;
        }
    }
}
