using InforceTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace InforceTestTask.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if(!registerViewModel.Password.Equals(registerViewModel.ConfirmPassword))
            {
                TempData["ErrorMessage"] = "Паролі не співпадають!";
                return View(registerViewModel);
            }

            return View();
        }
    }
}
