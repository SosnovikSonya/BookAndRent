
using Microsoft.AspNetCore.Mvc;


namespace BookAndRent.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

    }
}
