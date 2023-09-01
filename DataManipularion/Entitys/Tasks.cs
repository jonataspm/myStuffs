using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DataManipularion.Entitys
{
    public class Tasks
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string Id { get; set; }

        public string Title { get; set; }  

        public string Description { get; set; } 

        public DateTime DueDate { get; set; }

    }
}
