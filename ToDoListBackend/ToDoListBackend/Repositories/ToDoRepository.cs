using Microsoft.EntityFrameworkCore;
using ToDoListBackend.Data;
using ToDoListBackend.Models;
using ToDoListBackend.Repositories.Interfaces;

namespace ToDoListBackend.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext _appDbContext;

        public ToDoRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<ToDoItems> AddToDoItem(ToDoItems toDoItems)
        {
            _appDbContext.ToDoItems.Add(toDoItems);
            await _appDbContext.SaveChangesAsync();
            return toDoItems;
        }

        public async Task<List<ToDoItems>> GetToDoItems(int id)
        {
            return await _appDbContext.ToDoItems
                                        .Where(item => item.UserId == id)
                                        .ToListAsync();
        }
    }
}
