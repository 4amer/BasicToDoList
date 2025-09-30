using Microsoft.AspNetCore.Identity;
using ToDoListBackend.Scripts.Password.Interfaces;

namespace ToDoListBackend.Scripts.Password
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<object> _passwordHasher = new();

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VarifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
