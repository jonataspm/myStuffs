using DataManipularion.Entitys;
using DataManipularion.Entitys.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataManipularion.Service
{
    public class TasksService : ITasksService
    {
        MongoData _mongoData;
        private readonly IMongoCollection<Tasks> _mongoCollection;
        public TasksService(MongoData mongoData)
        {
            _mongoData = mongoData;
        }

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
                jsonTasks.Tasks = _mongoCollection.Find(_=> true).ToList();  

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
                _mongoCollection.InsertOne(newTask);
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
