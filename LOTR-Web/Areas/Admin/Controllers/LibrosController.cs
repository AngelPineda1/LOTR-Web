using Microsoft.AspNetCore.Mvc;

namespace LOTR_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LibrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
