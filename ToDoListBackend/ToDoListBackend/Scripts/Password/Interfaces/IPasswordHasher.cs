namespace ToDoListBackend.Scripts.Password.Interfaces
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
        public bool VarifyPassword(string hashedPassword, string providedPassword);
    }
}
