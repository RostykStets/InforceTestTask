using InforceTestTask.Models;

namespace InforceTestTask.Repositories.Interfaces
{
    public interface IRegisterRepository
    {
        Task<UserExtended> Register(RegisterModel userToRegister, string registrationKey);
    }
}
