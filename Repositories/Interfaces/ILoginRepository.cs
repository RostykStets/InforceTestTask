using InforceTestTask.Models;

namespace InforceTestTask.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<UserExtended> Login(string login, string password);
    }
}
