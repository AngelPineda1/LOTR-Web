using LOTR_Web.Models.ViewModels;
using LOTR_Web.Repositories.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace LOTR_Web.Controllers
{
    public class ForoController : Controller
    {
        public ForoController(IRepo repo)
        {
            Repo = repo;
        }

        public IRepo Repo { get; }

        bool existeFoto(int id)
        {
            string rutaImagen = $"wwwroot/publicaciones/{id}.png";
            if (System.IO.File.Exists(rutaImagen))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IActionResult Index()
        {
            var datos=Repo.PublicacionesRepository.GetPublicaciones().Select(x=>new ForoViewModel()
            {
                Fecha=x.Fecha,
                Id=x.Id,
                Texto=x.Texto,
                Archivo = existeFoto(x.Id)
            });
            if (datos == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(datos);
        }
    }
}
