using ToDoListBackend.Models;

namespace ToDoListBackend.Repositories.Interfaces
{
    public interface IToDoRepository
    {
        public Task<ToDoItems> AddToDoItem(ToDoItems toDoItems);
        public Task<List<ToDoItems>> GetToDoItems(int id);
    }
}
