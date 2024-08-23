using InforceTestTask.Models;

namespace InforceTestTask.Repositories.Interfaces
{
    public interface IRegistrationKeyRepository
    {
        Task<RegistrationKey?> getKeyFirst();
    }
}
