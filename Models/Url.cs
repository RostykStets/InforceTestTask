using System.ComponentModel.DataAnnotations.Schema;

namespace InforceTestTask.Models
{
    public class Url
    {
        public int Id { get; set; }
        public required string OriginalUrl { get; set; }
        public required string ShortenedUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserType UserType { get; set; }
    }
}
