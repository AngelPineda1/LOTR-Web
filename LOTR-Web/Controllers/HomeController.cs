using Microsoft.AspNetCore.Mvc;

namespace LOTR_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
