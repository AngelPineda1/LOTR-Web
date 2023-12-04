using LOTR_Web.Areas.Admin.Models;
using LOTR_Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LOTR_Web.Areas.Admin.Controllers
{
    public class PeliculasController : Controller
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
        public IActionResult Agregar(AdminPeliculasViewModel vm) 
        {
            return View(); 
        }
        public IActionResult Editar(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Editar(AdminPeliculasViewModel vm)
        {
            return View();
        }
        public IActionResult Eliminar(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(Peliculas p)
        {
            return View();
        }

    }
}
