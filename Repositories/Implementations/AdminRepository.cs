using InforceTestTask.Data;
using InforceTestTask.Models;
using InforceTestTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Admins.Where(x => x.Login == login).FirstOrDefaultAsync();
        }

        public async Task InsertAdmin(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
        }
    }
}
