using DataManipularion.Entitys;
using DataManipularion.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DataManipularion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private static TasksService tasksService = new TasksService(); 

        [HttpGet]
        public async Task<ActionResult<JsonTasks>> GetTasks()
        {
            return await tasksService.GetTasks();
        }

        [HttpPost]
        public async Task<ActionResult<JsonBase>> IncludeTasks(Tasks newTask)
        {
            return await tasksService.IncludeTasks(newTask);
        }

        [HttpPut("Alter/{id}")]
        public async Task<ActionResult<JsonBase>> AlterTasks(int id, Tasks updateTask)
        {
            return await tasksService.AlterTasks(id, updateTask);
        }
    }
}
