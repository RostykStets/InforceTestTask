namespace InforceTestTask.Models
{
    public class UrlViewModel
    {
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public string UserLogin { get; set; }
        public DateTime CreatedDate { get; set; }
        public UrlViewModel() { }
        public UrlViewModel(string originalUrl, string shortenedUrl, string userLogin, DateTime createdDate)
        {
            OriginalUrl = originalUrl;
            ShortenedUrl = shortenedUrl;
            UserLogin = userLogin;
            CreatedDate = createdDate;
        }
    }
}
