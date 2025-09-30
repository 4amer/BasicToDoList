using ToDoListBackend.Models;

namespace ToDoListBackend.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<Users> RegistraterAsync(Users user)
    }
}
