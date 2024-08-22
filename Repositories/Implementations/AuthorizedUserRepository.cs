using InforceTestTask.Data;
using InforceTestTask.Models;
using InforceTestTask.Repositories.Interfaces;

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
            return await _context.AuthorizedUsers.FindAsync(login);
        }
    }
}
