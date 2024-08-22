using InforceTestTask.Data;
using InforceTestTask.Models;
using InforceTestTask.Repositories.Interfaces;

namespace InforceTestTask.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly TaskDbContext _context;

        public AdminRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<Admin?> GetAdminById(int adminId)
        {
            return await _context.Admins.FindAsync(adminId);
        }

        public async Task<Admin?> GetAdminByLogin(string login)
        {
            return await _context.Admins.FindAsync(login);
        }
    }
}
