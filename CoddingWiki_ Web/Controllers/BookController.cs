using Microsoft.AspNetCore.Mvc;

namespace CoddingWiki__Web.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
