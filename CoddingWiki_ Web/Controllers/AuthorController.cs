using Microsoft.AspNetCore.Mvc;

namespace CoddingWiki__Web.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
