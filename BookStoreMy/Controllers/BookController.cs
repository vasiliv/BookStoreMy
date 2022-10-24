using Microsoft.AspNetCore.Mvc;

namespace BookStoreMy.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
