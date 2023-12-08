using LOTR_Web.Models.ViewModels;
using LOTR_Web.Repositories.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace LOTR_Web.Controllers
{
    public class PeliculasController : Controller
    {
        public PeliculasController(IRepo repo)
        {
            Repo = repo;
        }

        public IRepo Repo { get; }

        public IActionResult Index()
        {
            var datos=Repo.PeliculasRepository.GetPeliculas().Select(x=>new PeliculasViewModelAnonimo()
            {
                Id = x.Id,
                Descripcion=x.Descripcion,
                Nombre=x.Nombre,
                FechaPublicacion=x.FechaPublicacion
            });
            if (datos == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(datos);
        }
        public IActionResult VerDetalles(string id)
        {
            id = id.Replace("-", " ");
            
            var datos = Repo.PeliculasRepository.GetPeliculaByNombre(id);
            PeliculasViewModelAnonimo vm = new PeliculasViewModelAnonimo()
            {
                Descripcion = datos.Descripcion,
                Nombre = datos.Nombre,
                Id = datos.Id,
                FechaPublicacion = datos.FechaPublicacion,
               
            };
            return View(vm);
        }
    }
}
