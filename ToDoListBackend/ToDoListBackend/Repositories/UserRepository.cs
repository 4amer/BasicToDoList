using Microsoft.EntityFrameworkCore;
using ToDoListBackend.Data;
using ToDoListBackend.Models;
using ToDoListBackend.Repositories.Interfaces;

namespace ToDoListBackend.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<Users> AddUserAsync(Users users)
        {
            await _appDbContext.Users.AddAsync(users);
            await _appDbContext.SaveChangesAsync();
            return users;
        }

        public async Task<Users> GetUserWithSameEmailAsync(string email)
        {
            Users userWithEmail = await _appDbContext.Users.FirstOrDefaultAsync(item => item.Email == email);
            return userWithEmail;
        }
    }
}
