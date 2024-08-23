using InforceTestTask.Models;
using InforceTestTask.Repositories.Interfaces;

namespace InforceTestTask.Repositories.Implementations
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IAuthorizedUserRepository _authorizedUserRepository;

        public LoginRepository(IAdminRepository adminRepository, IAuthorizedUserRepository authorizedUserRepository)
        {
            _adminRepository = adminRepository;
            _authorizedUserRepository = authorizedUserRepository;
        }

        public async Task<UserExtended> Login(string login, string password)
        {
            UserExtended userToReturn = new();
            string storedPasswordHash;
            var admin = await _adminRepository.GetAdminByLogin(login);
            if (admin != null)
            {
                storedPasswordHash = admin.PasswordHash;
                if (BCrypt.Net.BCrypt.EnhancedVerify(password, storedPasswordHash))
                {
                    userToReturn = new UserExtended(admin);
                }
                else
                {
                    userToReturn.ErrorMsg = "Ви ввели неправильний пароль!";
                }
                return userToReturn;
            }
            var user = await _authorizedUserRepository.GetUserByLogin(login);
            if(user != null) 
            {
                storedPasswordHash = user.PasswordHash;
                if (BCrypt.Net.BCrypt.EnhancedVerify(password, storedPasswordHash))
                {
                    userToReturn = new UserExtended(user);
                }
                else
                {
                    userToReturn.ErrorMsg = "Ви ввели неправильний пароль!";
                }
                return userToReturn;
            }

            userToReturn.ErrorMsg = "Користувача з таким логіном не знайдено!";
            return userToReturn;
        }
    }
}
