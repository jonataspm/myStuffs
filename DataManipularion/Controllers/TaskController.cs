using DataManipularion.Entitys;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DataManipularion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private static Singleton singleton = Singleton.GetInstance();

        private static List<Tasks> fakeTasksBase = new List<Tasks>();


        [HttpGet("Tasks")]
        public ActionResult<JsonTasks> GetTasks()
        {
            var jsonTasks = new JsonTasks();
            try
            {
                jsonTasks.Success = true;
                jsonTasks.Tasks = fakeTasksBase;

                return jsonTasks;
            }
            catch (Exception ex)
            {
                jsonTasks.SetError(ex.Message);

                return jsonTasks;
            };
        }

        [HttpPost("Tasks")]
        public ActionResult<JsonBase> IncludeTasks(Tasks newTask)
        {
            var jsonBase = new JsonBase();
            try
            {
                newTask.AddId(singleton.Id());

                fakeTasksBase.Add(newTask);

                jsonBase.Success = true;
                jsonBase.Message = "Inclido";

                return jsonBase;
            }
            catch (Exception ex)
            {
                jsonBase.SetError(ex.Message);

                return jsonBase;
            }
        }

        [HttpPut("Tasks/{id}")]
        public ActionResult<JsonBase> AlterTasks(int id, Tasks updateTask)
        {
            var jsonBase = new JsonBase();
            try
            {
                foreach (var task in fakeTasksBase)
                {
                    if (task.Id != id)
                        continue;

                    task.Title = updateTask.Title;
                    task.Description = updateTask.Description;
                    task.DueDate = updateTask.DueDate;

                    jsonBase.Success = true;
                    jsonBase.Message = "Alterada";

                    return jsonBase;
                }

                throw new Exception("Task não encontrada");

            }
            catch (Exception ex)
            {
                jsonBase.SetError(ex.Message);

                return jsonBase;
            }
        }
    }
}
