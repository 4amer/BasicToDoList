using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ToDoListBackend.Models
{
    public class ToDoItems
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description{ get; set; }
        public bool IsDone { get; set; }
        public int UserId { get; set; }
    }
}