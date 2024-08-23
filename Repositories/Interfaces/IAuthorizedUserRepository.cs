using InforceTestTask.Models;

namespace InforceTestTask.Repositories.Interfaces
{
    public interface IAuthorizedUserRepository
    {
        Task<AuthorizedUser?> GetUserById(int userId);
        Task<AuthorizedUser?> GetUserByLogin(string login);
        Task InsertUser(AuthorizedUser user);
    }
}
