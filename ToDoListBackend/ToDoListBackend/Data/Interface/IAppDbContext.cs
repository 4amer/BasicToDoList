using Microsoft.EntityFrameworkCore;
using ToDoListBackend.Models;

namespace ToDoListBackend.Data.Interface
{
    public interface IAppDbContext
    {
        public DbSet<ToDoItems> ToDoItems { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
