namespace InforceTestTask.Models
{
    public class RegisterViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string RegistrationKey { get; set; }
        public UserType UserType { get; set; }
    }
}
