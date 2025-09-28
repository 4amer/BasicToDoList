using System.ComponentModel.DataAnnotations;

namespace ToDoListBackend.Models
{
    public class ToDoInfo
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string Discription { get; set; }
        public bool IsDone { get; set; }
    }
}
