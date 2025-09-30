using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoListBackend.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}