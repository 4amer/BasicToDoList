namespace ToDoListBackend.Models
{
    public class AuthRequst
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Expire { get; set; }
    }
}
