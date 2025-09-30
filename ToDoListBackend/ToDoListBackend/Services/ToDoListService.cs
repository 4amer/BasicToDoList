using ToDoListBackend.Models;
using ToDoListBackend.Repositories.Interfaces;
using ToDoListBackend.Services.Interfaces;

namespace ToDoListBackend.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoListService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<ToDoItems> CreateAndAddItemAsync(ToDoItems item)
        {
            item.UserId = 1;
            item.IsDone = false;
            return await _toDoRepository.AddToDoItem(item);
        }

        public async Task<List<ToDoItems>> GetItemsByIdAsync(int id)
        {
            return await _toDoRepository.GetToDoItems(id);
        }
    }
}
