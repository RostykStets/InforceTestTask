using InforceTestTask.Data;
using InforceTestTask.Models;
using InforceTestTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.Repositories.Implementations
{
    public class UrlRepository : IUrlRepository
    {
        private readonly TaskDbContext _context;
        public UrlRepository(TaskDbContext context) 
        {
            _context = context;
        }

        public async Task DeleteUrl(int urlId)
        {
            Url? url = await _context.Urls.FindAsync(urlId);
            if (url != null)
            {
                _context.Urls.Remove(url);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Url?> getUrlById(int urlId)
        {
            return await _context.Urls.FindAsync(urlId);
        }

        public async Task<Url?> GetUrlByOriginalUrl(string originalUrl)
        {
            return await _context.Urls.Where(url => url.OriginalUrl == originalUrl).FirstOrDefaultAsync();
        }

        public async Task<Url?> GetUrlByShortenedUrl(string shortenedUrl)
        {
            return await _context.Urls.Where(url => url.ShortenedUrl == shortenedUrl).FirstOrDefaultAsync();
        }

        public Task<List<Url>> GetUrls()
        {
            return _context.Urls.ToListAsync();
        }

        public async Task<List<Url>> GetUrlsByUserId(int userId, UserType userType)
        {
            return await _context.Urls.Where(url => url.UserId == userId && url.UserType == userType).ToListAsync();
        }

        public async Task InsertUrl(Url url)
        {
            await _context.Urls.AddAsync(url);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUrl(Url url)
        {
            _context.Urls.Update(url);
            await _context.SaveChangesAsync();
        }
    }
}
