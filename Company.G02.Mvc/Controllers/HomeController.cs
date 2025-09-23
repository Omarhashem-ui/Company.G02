using Microsoft.AspNetCore.Mvc;

namespace Company.G02.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
