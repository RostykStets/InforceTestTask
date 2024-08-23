using InforceTestTask.Data;
using InforceTestTask.Models;
using InforceTestTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.Repositories.Implementations
{
    public class AuthorizedUserRepository : IAuthorizedUserRepository
    {
        private readonly TaskDbContext _context;

        public AuthorizedUserRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<AuthorizedUser?> GetUserById(int userId)
        {
            return await _context.AuthorizedUsers.FindAsync(userId);
        }

        public async Task<AuthorizedUser?> GetUserByLogin(string login)
        {
            return await _context.AuthorizedUsers.Where(x => x.Login == login).FirstOrDefaultAsync();
        }

        public async Task InsertUser(AuthorizedUser user)
        {
            await _context.AuthorizedUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
