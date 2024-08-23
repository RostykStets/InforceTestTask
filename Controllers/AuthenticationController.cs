using InforceTestTask.Models;
using InforceTestTask.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InforceTestTask.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IRegisterRepository _registerRepository;

        public AuthenticationController(ILoginRepository loginRepository, IRegisterRepository registerRepository)
        {
            _loginRepository = loginRepository;
            _registerRepository = registerRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var user = await _loginRepository.Login(loginViewModel.Login, loginViewModel.Password);
            if(!user.ErrorMsg.Equals(""))
            {
                TempData["ErrorMessage"] = user.ErrorMsg;
                return View(loginViewModel);
            }
            return RedirectToAction("Index", "URL", user);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(!registerViewModel.Password.Equals(registerViewModel.ConfirmPassword))
            {
                TempData["ErrorMessage"] = "Паролі не співпадають!";
                return View(registerViewModel);
            }

            RegisterModel model = new RegisterModel();
            model.Login = registerViewModel.Login;
            model.Password = registerViewModel.Password;
            model.UserType = registerViewModel.UserType;

            var user = await _registerRepository.Register(model, registerViewModel.RegistrationKey);

            if (!user.ErrorMsg.Equals(""))
            {
                TempData["ErrorMessage"] = user.ErrorMsg;
                return View(registerViewModel);
            }

            return RedirectToAction("Index", "URL", user);
        }
    }
}
