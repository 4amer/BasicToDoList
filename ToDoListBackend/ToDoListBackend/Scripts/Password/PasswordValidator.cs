using ToDoListBackend.Scripts.Password.Interfaces;

namespace ToDoListBackend.Scripts.Password
{
    public class PasswordValidator: IPasswordValidator
    {
        public (bool isValid, string errorText) Validate(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return (false, "Password cannot be empty");

            if (password.Length < 8)
                return (false, "Password must be at least 8 characters long");

            if (!password.Any(char.IsDigit))
                return (false, "Password must contain at least one number");

            if (!password.Any(char.IsUpper))
                return (false, "Password must contain at least one uppercase letter");

            if (!password.Any(char.IsLower))
                return (false, "Password must contain at least one lowercase letter");

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                return (false, "Password must contain at least one special character");

            if (IsCommonPassword(password))
                return (false, "Password is too common");

            if (HasSequentialCharacters(password, 3))
                return (false, "Password contains sequential characters");

            return (true, "Password is strong");
        }

        private bool IsCommonPassword(string password)
        {
            var commonPasswords = new HashSet<string>
            {
                "password", "123456", "qwerty", "admin", "welcome"
            };
            return commonPasswords.Contains(password.ToLower());
        }

        private bool HasSequentialCharacters(string password, int maxSequence)
        {
            for (int i = 0; i <= password.Length - maxSequence; i++)
            {
                var sequence = password.Substring(i, maxSequence);
                if (IsSequential(sequence))
                    return true;
            }
            return false;
        }

        private bool IsSequential(string str)
        {
            var chars = str.ToCharArray();
            for (int i = 1; i < chars.Length; i++)
            {
                if (chars[i] - chars[i - 1] != 1)
                    return false;
            }
            return true;
        }
    }
}
