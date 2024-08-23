using InforceTestTask.Data;
using InforceTestTask.Models;
using InforceTestTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.Repositories.Implementations
{
    public class RegistrationKeyRepository : IRegistrationKeyRepository
    {
        private readonly TaskDbContext _context;

        public RegistrationKeyRepository(TaskDbContext context) 
        {
            _context = context;
        }
        public async Task<RegistrationKey?> getKeyFirst()
        {
            return await _context.RegistrationKeys.FirstOrDefaultAsync();
        }
    }
}
