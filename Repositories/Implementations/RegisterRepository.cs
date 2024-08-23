using BCrypt.Net;
using InforceTestTask.Models;
using InforceTestTask.Repositories.Interfaces;

namespace InforceTestTask.Repositories.Implementations
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IAuthorizedUserRepository _authorizedUserRepository;
        private readonly IRegistrationKeyRepository _registrationKeyRepository;

        public RegisterRepository(IAdminRepository adminRepository, IAuthorizedUserRepository authorizedUserRepository, 
            IRegistrationKeyRepository registrationKeyRepository)
        {
            _adminRepository = adminRepository;
            _authorizedUserRepository = authorizedUserRepository;
            _registrationKeyRepository = registrationKeyRepository;
        }
        public async Task<UserExtended> Register(RegisterModel userToRegister, string registrationKey)
        {
            UserExtended userToReturn = new UserExtended();

            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(userToRegister.Password);
            if(userToRegister.UserType == UserType.Admin)
            {
                var _registrationKey = await _registrationKeyRepository.getKeyFirst();
                if(registrationKey == String.Empty || registrationKey == "")
                {
                    userToReturn.ErrorMsg = "Ви не ввели реєстраційний ключ!";
                    return userToReturn;
                }
                if(!_registrationKey.Key.Equals(registrationKey))
                {
                    userToReturn.ErrorMsg = "Ви ввели неправильний реєстраційний ключ!";
                    return userToReturn;
                }

                var admin = await _adminRepository.GetAdminByLogin(userToRegister.Login);
                if(admin == null)
                {
                    admin = new Admin();
                    admin.Login = userToRegister.Login;
                    admin.PasswordHash = passwordHash;
                    admin.UserType = UserType.Admin;
                    await _adminRepository.InsertAdmin(admin);
                    admin = await _adminRepository.GetAdminByLogin(admin.Login);
                    userToReturn = new UserExtended(admin);
                    return userToReturn;
                }
                else
                    userToReturn.ErrorMsg = "Адміністратор з таким логіном вже існує!";
            }
            else if(userToRegister.UserType == UserType.AuthorizedUser)
            {
                var user = await _authorizedUserRepository.GetUserByLogin(userToRegister.Login);
                if (user == null)
                {
                    user = new AuthorizedUser();
                    user.Login = userToRegister.Login;
                    user.PasswordHash = passwordHash;
                    user.UserType = UserType.Admin;
                    await _authorizedUserRepository.InsertUser(user);
                    user = await _authorizedUserRepository.GetUserByLogin(user.Login);
                    userToReturn = new UserExtended(user);
                    return userToReturn;
                }
                else
                    userToReturn.ErrorMsg = "користувач з таким логіном вже існує!";
            }

            return userToReturn;
        }
    }
}
