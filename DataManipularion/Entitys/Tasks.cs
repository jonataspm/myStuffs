using System.ComponentModel.DataAnnotations;

namespace DataManipularion.Entitys
{
    public class Tasks
    {
        [Key]
        public int Id { get; private set; }

        public string Title { get; set; }  

        public string Description { get; set; }

        public DateTime DueDate { get; set; }


        public void AddId(int id) {
            Id = id;
        }
    }
}
