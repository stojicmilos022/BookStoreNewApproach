using Microsoft.AspNetCore.Mvc;

namespace CoddingWiki__Web.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
