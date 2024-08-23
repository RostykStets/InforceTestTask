using InforceTestTask.Models;
using InforceTestTask.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InforceTestTask.Controllers
{
    public class UrlController : Controller
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IAuthorizedUserRepository _authorizedUserRepository;
        private readonly IUrlRepository _urlRepository;
        private readonly IShorteningAlgorithmRepository _shorteningAlgorithmRepository;
        private List<Url> _urls;
        private User? _user;

        public UrlController(IAdminRepository adminRepository, IAuthorizedUserRepository authorizedUserRepository, 
            IUrlRepository urlRepository, IShorteningAlgorithmRepository shorteningAlgorithmRepository) 
        {
            _adminRepository = adminRepository;
            _authorizedUserRepository = authorizedUserRepository;
            _urlRepository = urlRepository;
            _shorteningAlgorithmRepository = shorteningAlgorithmRepository;
            _urls = new List<Url>();
            _user = null;
        }
        public async Task<IActionResult> Index(User? user)
        {
            var urls = await _urlRepository.GetUrls();
            _urls = urls;
            //var urls = new List<Url>();
            //Url url = new Url{ 
            //    OriginalUrl = "youtube.com",
            //    ShortenedUrl = "ytb.com",
            //    CreatedDate = DateTime.Now,
            //    UserId = 2,
            //    UserType = UserType.AuthorizedUser
            //};
            //urls.Add(url);
            _user = user;
            if (_user.Login == null)
                ViewBag.User = null;
            else
                ViewBag.User = user;
            return View(_urls);
        }

        public async Task ShortUrl(User user, string originalUrl)
        {
            string shortenedUrl = _shorteningAlgorithmRepository.ShorteningAlgorithm(originalUrl);
            Url url = new Url(originalUrl, shortenedUrl, user.Id, user.UserType);
            await _urlRepository.InsertUrl(url);
        }

        public async Task<IActionResult> GoByShortenedUrl(string shortenedUrl)
        {
            var url = await _urlRepository.GetUrlByShortenedUrl(shortenedUrl);
            return Redirect(url.OriginalUrl);
        }

        public async Task<IActionResult> UrlInfo(int urlId, UserType userType)
        {
            if (_user.Login == null)
            {
                TempData["ErrorMessage"] = "Видаляти записи може тільки авторизовані користувачі!";
                return View();
            }

            var url = _urls.Where(x => x.Id == urlId).First();
            User user = new User();
            if (userType == UserType.Admin)
            {
                Admin? admin = await _adminRepository.GetAdminById(url.UserId);
                if(admin != null) user.Login = admin.Login;
            }
            else
            {
                AuthorizedUser? authorizedUser = await _authorizedUserRepository.GetUserById(url.UserId);
                if(authorizedUser != null) user.Login = authorizedUser.Login;
            }

            UrlViewModel urlViewModel = new UrlViewModel(url.OriginalUrl, url.ShortenedUrl, user.Login, url.CreatedDate);

            return View(urlViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRecord(int urlId)
        {
            if (_user.Login == null)
            {
                TempData["ErrorMessage"] = "Видаляти записи може тільки авторизовані користувачі!";
                return View();
            }

            await _urlRepository.DeleteUrl(urlId);

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
