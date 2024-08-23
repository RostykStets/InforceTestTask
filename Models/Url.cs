using System.ComponentModel.DataAnnotations.Schema;

namespace InforceTestTask.Models
{
    public class Url
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserType UserType { get; set; }

        public Url() { }

        public Url(string originalUrl, string shortenedUrl, int userId, UserType userType)
        {
            OriginalUrl = originalUrl;
            ShortenedUrl = shortenedUrl;
            UserId = userId;
            UserType = userType;
            CreatedDate = DateTime.Now;
        }
    }
}
