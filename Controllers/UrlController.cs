using InforceTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace InforceTestTask.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index(User? user)
        {
            var urls = new List<Url>();
            Url url = new Url{ 
                OriginalUrl = "youtube.com",
                ShortenedUrl = "ytb.com",
                CreatedDate = DateTime.Now,
                UserId = 2,
                UserType = UserType.AuthorizedUser
            };
            urls.Add(url);
            return View(urls);
        }

        public void GoByShortenedUrl(string shortenedUrl)
        {

        }

        public IActionResult UrlInfo(int urlId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteRecord(int urlId)
        {
            TempData["ErrorMessage"] = "Видаляти записи може тільки авторизовані користувачі!";
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
