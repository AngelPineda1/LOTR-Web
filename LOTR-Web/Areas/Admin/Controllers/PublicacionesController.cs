using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace LOTR_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PublicacionesController : Controller
    {
        public IRepo Repo { get; }

        public PublicacionesController(IRepo repo)
        {
            Repo = repo;
        }
        public IActionResult Index()
        {
            var datos=Repo.PublicacionesRepository.GetPublicaciones();
            return View(datos);
        }
        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(Publicaciones p)
        {
            if (string.IsNullOrWhiteSpace(p.Texto))
            {
                ModelState.AddModelError("", "Escriba el texto de la publicacion");
            }
            if (ModelState.IsValid)
            {
                p.Fecha = DateTime.Now;
                Repo.PublicacionesRepository.InsertPublicacion(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public IActionResult Editar(int id)
        {
            var datos=Repo.PublicacionesRepository.GetPublicacionById(id);
            if(datos == null)
            {
                return RedirectToAction("Index");
            }
            else
            {

            return View(datos);
            }

        }

        [HttpPost]
        public IActionResult Editar(Publicaciones p)
        {
            if (string.IsNullOrWhiteSpace(p.Texto))
            {
                    ModelState.AddModelError("", "Escriba el texto de la publicacion");
            }
            else
            {
                
                if (ModelState.IsValid)
                {
                    var datos = Repo.PublicacionesRepository.GetPublicacionById(p.Id);

                    if(datos == null)
                    {
                        return RedirectToAction("Index");
                    }
                    datos.Fecha = p.Fecha;
                    datos.Texto = p.Texto;
                    Repo.PublicacionesRepository.UpdatePublicacion(datos);
                    return RedirectToAction("Index");
                }
            }
            return View(p);
        }
        public IActionResult Eliminar(int id)
        {
            var datos = Repo.PublicacionesRepository.GetPublicacionById(id);
            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            else
            {

                return View(datos);
            }
        }
        [HttpPost]
        public IActionResult Eliminar(Publicaciones p)
        {
            var datos = Repo.PublicacionesRepository.GetPublicacionById(p.Id);
            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            Repo.PublicacionesRepository.DeletePublicacion(datos);
            return RedirectToAction("Index");
        }
    }
}
