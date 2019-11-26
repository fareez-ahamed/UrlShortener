using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Services;
using UrlShortener.ViewModels;

namespace UrlShortener.Controllers
{
    [Route("/")]
    public class UrlController : Controller
    {        

        private readonly IShorteningService _service;

        public UrlController(IShorteningService service){
            _service = service;
        }

        [HttpGet("/")]
        public ViewResult Index() {
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

        public IActionResult RedirectUrl(string Hash)
        {
            return View();
        }
    }
}