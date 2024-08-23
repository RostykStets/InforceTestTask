using InforceTestTask.Models;

namespace InforceTestTask.Repositories.Interfaces
{
    public interface IUrlRepository
    {
        Task<List<Url>> GetUrls();
        Task<Url?> getUrlById(int urlId);
        Task<List<Url>> GetUrlsByUserId(int userId, UserType userType);
        Task<Url?> GetUrlByOriginalUrl(string originalUrl);
        Task<Url?> GetUrlByShortenedUrl(string shortenedUrl);
        Task InsertUrl(Url url);
        Task DeleteUrl(int urlId);
        Task UpdateUrl(Url url);
    }
}
