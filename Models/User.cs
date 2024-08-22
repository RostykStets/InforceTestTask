
namespace InforceTestTask.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Login { get; set; }
        public required string PasswordHash { get; set; }
        public UserType UserType { get; set; }
    }
}
