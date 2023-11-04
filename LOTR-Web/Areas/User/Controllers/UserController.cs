using Microsoft.AspNetCore.Mvc;

namespace LOTR_Web.Areas.User.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
