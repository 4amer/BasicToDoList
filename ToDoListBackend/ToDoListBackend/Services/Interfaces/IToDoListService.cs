using ToDoListBackend.Models;

namespace ToDoListBackend.Services.Interfaces
{
    public interface IToDoListService
    {
        public async Task CreateAndAddItemAsync(ToDoItems item);
        public async Task<ToDoItems[]> GetItemsByIdAsync(int id);
    }
}
