using DataManipularion.Entitys;
using DataManipularion.Entitys.Base;
using DataManipularion.Service;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace DataManipularion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TasksService _tasksService = new TasksService();

        public TaskController(TasksService tasksService) => _tasksService = tasksService;

        [HttpGet]
        public async Task<ActionResult<JsonTasks>> GetTasks()
        {
            return await _tasksService.GetTasks();
        }

        [HttpPost]
        public async Task<ActionResult<JsonBase>> IncludeTasks(Tasks newTask)
        {
            return await _tasksService.IncludeTasks(newTask);
        }

        [HttpPut("Alter/{id}")]
        public async Task<ActionResult<JsonBase>> AlterTasks(int id, Tasks updateTask)
        {
            return await _tasksService.AlterTasks(id, updateTask);
        }
    }
}
