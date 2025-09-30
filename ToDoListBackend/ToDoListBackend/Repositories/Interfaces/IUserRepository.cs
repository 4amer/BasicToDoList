using ToDoListBackend.Models;

namespace ToDoListBackend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<Users> AddUserAsync(Users users);
        public Task<Users> GetUserWithSameEmailAsync(string email);
    }
}
