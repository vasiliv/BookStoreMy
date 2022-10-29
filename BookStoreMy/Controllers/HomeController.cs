using Microsoft.AspNetCore.Mvc;

namespace BookStoreMy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
