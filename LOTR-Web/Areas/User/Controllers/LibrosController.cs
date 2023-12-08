using LOTR_Web.Repositories.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LOTR_Web.Models.ViewModels;
namespace LOTR_Web.Areas.User.Controllers
{
        [Area("User")]
        [Authorize(Roles = "User, Admin")]
    public class LibrosController : Controller
    {
        public LibrosController(IRepo repo)
        {
            Repo = repo;
        }

        public IRepo Repo { get; }

        public IActionResult Index()
        {
            var datos = Repo.LibrosRepository.GetAll().Select(x => new LibrosViewModel ()
            {
                Descripcion = x.Descripcion,
                Id = x.Id,
                Nombre = x.Nombre,
                FechaPublicacion = x.FechaPublicacion,
                TiendaOficial = x.TiendaOficial,
            });
            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            return View(datos);
        }
        public IActionResult VerDetalles(string id)
        {
            id = id.Replace("-", " ");
            var datos = Repo.LibrosRepository.GetLibroByNombre(id);
            LibrosViewModel vm = new LibrosViewModel()
            {
                Descripcion = datos.Descripcion,
                Nombre = datos.Nombre,
                Id = datos.Id,
                FechaPublicacion = datos.FechaPublicacion,
                Editorial = datos.Editorial,
                TiendaOficial = datos.TiendaOficial,
            };
            return View(vm);
        }
    }
}
