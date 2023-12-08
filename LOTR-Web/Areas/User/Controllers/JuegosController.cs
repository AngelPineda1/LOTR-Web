using LOTR_Web.Models.ViewModels;
using LOTR_Web.Repositories.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LOTR_Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User, Admin")]
    public class JuegosController : Controller
    {
        public JuegosController(IRepo repo)
        {
            Repo = repo;
        }

        public IRepo Repo { get; }

        public IActionResult Index()
        {
            var datos = Repo.JuegosRepository.GetJuegos().Select(x => new JuegosAnonimoViewModel()
            {
                Descripcion = x.Descripcion,
                Nombre = x.Nombre,
                Id = x.Id,
                FechaPublicacion = x.FechaPublicacion,
                Clasificacion = x.Clasificacion,
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

            var datos = Repo.JuegosRepository.GetJuegosByNombre(id);
            JuegosAnonimoViewModel vm = new JuegosAnonimoViewModel()
            {
                Descripcion = datos.Descripcion,
                Nombre = datos.Nombre,
                Id = datos.Id,
                FechaPublicacion = datos.FechaPublicacion,
                Clasificacion = datos.Clasificacion,
            };
            return View(vm);
        }
    }
}
