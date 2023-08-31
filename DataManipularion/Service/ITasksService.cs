using DataManipularion.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace DataManipularion.Service
{
    public interface ITasksService
    {
        public Task<ActionResult<JsonTasks>> GetTasks();

        public Task<ActionResult<JsonBase>> IncludeTasks(Tasks newTask);

        public Task<ActionResult<JsonBase>> AlterTasks(int id, Tasks updateTask);
       

    }
}
