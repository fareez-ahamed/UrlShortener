using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Data.Repositories;
using UrlShortener.Services;
using UrlShortener.ViewModels;

namespace UrlShortener.Controllers
{
    [Route("/")]
    public class UrlController : Controller
    {

        private readonly IShorteningService _service;
        private readonly IUrlRepository _urlRepo;

        public UrlController(IShorteningService service, IUrlRepository urlRepo)
        {
            _service = service;
            _urlRepo = urlRepo;
        }

        [HttpGet("/")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost("shorten")]
        public ViewResult Shorten(ShortenModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            model.ShortenedUrl = _service.ShortenAndStore(model.Url);
            return View(model);
        }

        [HttpGet("/u/{hash}")]
        public IActionResult RedirectUrl(string hash)
        {
            return Redirect(_urlRepo.getUrl(hash));
        }
    }
}