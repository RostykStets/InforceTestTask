using InforceTestTask.Models;

namespace InforceTestTask.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admin?> GetAdminById(int adminId);
        Task<Admin?> GetAdminByLogin(string login);
    }
}
