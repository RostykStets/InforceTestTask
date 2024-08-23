using System.ComponentModel.DataAnnotations;

namespace InforceTestTask.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login is required")]
        [EmailAddress(ErrorMessage = "Invalid login")]
        [Display(Name = "login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
