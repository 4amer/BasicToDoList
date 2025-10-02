using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IConfiguration _configuration;
        public AuthService(IUserRepository userRepository,
            IPasswordValidator passwordValidator,
            IPasswordHasher passwordHasher,
            IConfiguration configuration) 
        {
            _userRepository = userRepository;
            _passwordValidator = passwordValidator;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public async Task<Users> RegistraterAsync(Users user)
        {
            if (user.UserName == string.Empty)
                throw new ArgumentException("User name is empty!");

            Users userByEmail = await _userRepository.GetUserWithSameEmailAsync(user.Email);
            if (userByEmail != null)
                throw new ArgumentException($"User with {user.Email} is olready exist");

            string password = user.PasswordHash;

            var validationResult = _passwordValidator.Validate(password);

            if (!validationResult.isValid)
                throw new ArgumentException(validationResult.errorText);

            string hashedPassword = _passwordHasher.HashPassword(password);

            user.PasswordHash = hashedPassword;

            await _userRepository.AddUserAsync(user);
            return user;
        }

        public async Task<AuthRequst> LogginAsync(Users user)
        {
            string password = user.PasswordHash;
            Users userByEmail = await _userRepository.GetUserWithSameEmailAsync(user.Email);
            
            if(userByEmail == null)
                throw new ArgumentException("There is no user with this Email");

            string hashedPassword = userByEmail.PasswordHash;
            bool isSamePassword = _passwordHasher.VarifyPassword(hashedPassword, password);

            if (!isSamePassword)
                throw new ArgumentException("Uncorrect Password");

            AuthRequst authRequst = GenerateJWTTokenAndAuthRequest(userByEmail);

            return authRequst;
        }

        private AuthRequst GenerateJWTTokenAndAuthRequest(Users user)
        {
            var secret = _configuration["JWT:Secret"] ?? throw new Exception("Secret is not configurated");

            var key = Encoding.ASCII.GetBytes(secret);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(24),
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            AuthRequst authRequst = new AuthRequst()
            {
                Token = tokenHandler.WriteToken(token),
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                Expire = DateTime.UtcNow.AddHours(24),
            };

            return authRequst;
        }
    }
}
