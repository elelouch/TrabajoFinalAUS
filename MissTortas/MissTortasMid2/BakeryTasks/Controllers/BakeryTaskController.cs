using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MissTortasMid2.BakeryTasks.Dto;
using MissTortasMid2.BakeryTasks.Entity;

namespace MissTortasMid2.BakeryTasks.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class BakeryTaskController : Controller
    {
        [HttpGet]
        public List<BakeryTask> GetTasks()
        {
            return BakeryTask.tasks;
        }

        [HttpPost]
        public ActionResult<BakeryTask> PostTask(BakeryTaskDto dto)
        {
            if(!ModelState.IsValid)
            {
                NotFound();
            }
            var task = new BakeryTask
            {
                Description = dto.Description,
                Id = BakeryTask.NextID(),
                Name = dto.Name,
                UID = Guid.NewGuid().ToString(),
            };
            BakeryTask.tasks.Add(task);
            return task;
        }

        [HttpGet("{id}")]
        public ActionResult<BakeryTask> GetTask(int id)
        {
            var task = BakeryTask.tasks.FirstOrDefault(t => t.Id == id);
            if(task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpDelete("{id}")]
        public void DeleteTask(int id)
        {
            BakeryTask.tasks.RemoveAll(t => t.Id == id);
        }
    }
}
