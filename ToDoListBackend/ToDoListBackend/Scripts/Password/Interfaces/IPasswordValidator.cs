namespace ToDoListBackend.Scripts.Password.Interfaces
{
    public interface IPasswordValidator
    {
        public (bool isValid, string errorText) Validate(string password);
    }
}
