using Microsoft.AspNetCore.Mvc;

namespace LOTR_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PublicacionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Agregar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            return View();

        }

        [HttpPost]
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult Eliminar(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar()
        {
            return View();
        }
    }
}
