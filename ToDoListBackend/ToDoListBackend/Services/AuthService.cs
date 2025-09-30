using ToDoListBackend.Models;
using ToDoListBackend.Repositories.Interfaces;
using ToDoListBackend.Scripts.Password.Interfaces;
using ToDoListBackend.Services.Interfaces;

namespace ToDoListBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordValidator _passwordValidator;
        private readonly IPasswordHasher _passwordHasher;


        public AuthService(IUserRepository userRepository,
            IPasswordValidator passwordValidator,
            IPasswordHasher passwordHasher) 
        {
            _userRepository = userRepository;
            _passwordValidator = passwordValidator;
            _passwordHasher = passwordHasher;
        }

        public async Task<Users> RegistraterAsync(Users user)
        {
            if (user.UserName == string.Empty)
                throw new ArgumentException("User name is empty!");

            string password = user.PasswordHash;

            var validationResult = _passwordValidator.Validate(password);

            if (!validationResult.isValid)
                throw new ArgumentException(validationResult.errorText);

            string hashedPassword = _passwordHasher.HashPassword(password);

            user.PasswordHash = hashedPassword;

            await _userRepository.AddUserAsync(user);
            return user;
        }

        public async Task<Users> LogginAsync(Users user)
        {
            string password = user.PasswordHash;
            Users userByEmail = await _userRepository.GetUserWithSameEmailAsync(user.Email);
            
            if(userByEmail == null)
                throw new ArgumentException("There is no user with this Email");

            string hashedPassword = userByEmail.PasswordHash;
            bool isSamePassword = _passwordHasher.VarifyPassword(hashedPassword, password);

            if (!isSamePassword)
                throw new ArgumentException("Uncorrect Password");

            return user;
        }
    }
}
