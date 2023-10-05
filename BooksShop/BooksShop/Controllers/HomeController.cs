using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Product() => View();
    }
}
