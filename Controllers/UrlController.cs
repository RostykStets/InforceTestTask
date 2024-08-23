using InforceTestTask.Models;
using InforceTestTask.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InforceTestTask.Controllers
{
    public class UrlController : Controller
    {
        private readonly IUrlRepository _urlRepository;
        private readonly IShorteningAlgorithmRepository _shorteningAlgorithmRepository;

        public UrlController(IUrlRepository urlRepository, IShorteningAlgorithmRepository shorteningAlgorithmRepository) 
        {
            _urlRepository = urlRepository;
            _shorteningAlgorithmRepository = shorteningAlgorithmRepository;
        }
        public async Task<IActionResult> Index(User user)
        {
            var urls = await _urlRepository.GetUrls();
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            var tuple = new Tuple<List<Url>, User?>(urls, user);
            return View(tuple);
        }

        [HttpPost]
        public async Task<IActionResult> ShortUrl(string originalUrl, User user)
        {
            string shortenedUrl = await _shorteningAlgorithmRepository.ShorteningAlgorithm(originalUrl);
            Url url = new Url(originalUrl, shortenedUrl, user.Id, user.UserType);
            await _urlRepository.InsertUrl(url);
            
            return RedirectToAction("Index", "URL", user);
        }

        public async Task<IActionResult> GoByShortenedUrl(string shortenedUrl)
        {
            var url = await _urlRepository.GetUrlByShortenedUrl(shortenedUrl);
            var _url = url ?? new Url();
            return Redirect(_url.OriginalUrl);
        }

        [HttpPost]
        public async Task<IActionResult> UrlInfo(int urlId, User currentUser)
        {
            if (currentUser.Login == null || currentUser.IsDefault())
            {
                TempData["ErrorMessage"] = "Видаляти записи може тільки авторизовані користувачі!";
                return RedirectToAction("Index", "URL");
            }

            var url = await _urlRepository.getUrlById(urlId);

            UrlViewModel urlViewModel = new UrlViewModel(url.OriginalUrl, url.ShortenedUrl, currentUser.Login, url.CreatedDate);
            var tuple = new Tuple<UrlViewModel, User>(urlViewModel, currentUser);
            return View(tuple);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRecord(int urlId, User currentUser)
        {
            if (currentUser.Login == null || currentUser.IsDefault())
            {
                TempData["ErrorMessage"] = "Видаляти записи може тільки авторизовані користувачі!";
                return RedirectToAction("Index", "URL");
            }
            var url = await _urlRepository.getUrlById(urlId);
            if(url.UserId != currentUser.Id || url.UserType != currentUser.UserType)
            {
                TempData["ErrorMessage"] = "Цей запис був зроблений не Вами, тому ви не можете його видалити!";
                return RedirectToAction("Index");
            }
            await _urlRepository.DeleteUrl(urlId);
            return RedirectToAction("Index", "URL", currentUser);
        }

        public IActionResult About(User user)
        {
            if(user.IsDefault())
                ViewBag.User = null;
            else
                ViewBag.User = user;
            return View();
        }
    }
}
