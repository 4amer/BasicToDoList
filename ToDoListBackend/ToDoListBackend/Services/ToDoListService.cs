using ToDoListBackend.Models;
using ToDoListBackend.Services.Interfaces;

namespace ToDoListBackend.Services
{
    public class ToDoListService : IToDoListService
    {
        public async Task CreateAndAddItemAsync(ToDoItems item)
        {

        }

        public async Task<ToDoItems[]> GetItemsByIdAsync(int id)
        {
            return null;
        }
    }
}
