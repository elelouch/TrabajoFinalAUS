using MissTortasMid2.Controllers;
using MissTortasMid2.Entity;
using MissTortasMid2.Entity.Dto;
namespace MissTortasEngineTest
{
    public class BakeryTaskControllerTest
    {
        [Fact]
        public void TaskShouldntBeFound()
        {
            var controller = new BakeryTaskController();
            var task = controller.GetTasks().Find(t => t.Id == 123490875);
            Assert.Null(task);
        }

        [Fact]
        public void TaskIsCorrectlyAdded()
        {
            var controller = new BakeryTaskController();
            var task = new BakeryTaskDto { Description = "test", Name = "Naughtiness" };
            var createdTask = controller.PostTask(task);
        }

    }
}
    