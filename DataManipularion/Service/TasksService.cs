using DataManipularion.Entitys;
using DataManipularion.Entitys.Base;
using Microsoft.AspNetCore.Mvc;

namespace DataManipularion.Service
{
    public class TasksService : ITasksService
    {
        //private MongoData _mongo;
        public TasksService() { } 

        public async Task<ActionResult<JsonBase>> AlterTasks(int id, Tasks updateTask)
        {
            var jsonBase = new JsonBase();
            try
            {

                throw new Exception("Task não encontrada");

            }
            catch (Exception ex)
            {
                jsonBase.SetError(ex.Message);

                return jsonBase;
            }
        }

        public async Task<ActionResult<JsonTasks>> GetTasks()
        {
            var jsonTasks = new JsonTasks();

            try
            {
                jsonTasks.Success = true;

                return jsonTasks;
            }
            catch (Exception ex)
            {
                jsonTasks.SetError(ex.Message);

                return jsonTasks;
            }
        }

        public async Task<ActionResult<JsonBase>> IncludeTasks(Tasks newTask)
        {
            var jsonBase = new JsonBase();
            try
            {

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
    }
}
