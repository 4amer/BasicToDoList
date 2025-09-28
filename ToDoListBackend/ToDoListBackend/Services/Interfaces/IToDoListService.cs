using ToDoListBackend.Models;

namespace ToDoListBackend.Services.Interfaces
{
    public interface IToDoListService
    {
        public Task<ToDoItems> CreateAndAddItemAsync(ToDoItems item);
        public Task<List<ToDoItems>> GetItemsByIdAsync(int id);
    }
}
