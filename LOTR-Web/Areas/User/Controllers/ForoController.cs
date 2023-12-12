using LOTR_Web.Areas.Admin.Models;
using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LOTR_Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User, Admin")]
    public class ForoController : Controller
    {
        public IRepo Repo { get; }

        public ForoController(IRepo repo)
        {
            Repo = repo;
        }
        
        public IActionResult Index()
        {
            var datos = Repo.PublicacionesRepository.GetPublicaciones();
            return View(datos);
        }
        [HttpPost]
        public IActionResult Index(AdminPublicacionesViewModel vm)
        {

            vm.Publicaciones = Repo.PublicacionesRepository.GetPublicaciones().Publicaciones;
            if (string.IsNullOrWhiteSpace(vm.AgregarPublicaciones.Texto))
            {
                ModelState.AddModelError("", "Escriba el texto de la publicacion");
            }
            if (vm.AgregarPublicaciones.Archivo != null)
            {
                //MIME TYPE
                if (vm.AgregarPublicaciones.Archivo.ContentType != "image/png")
                {
                    ModelState.AddModelError("", "Solo se permiten imagenes PNG");
                }
                if (vm.AgregarPublicaciones.Archivo.Length > 1000 * 1024)
                {
                    ModelState.AddModelError("", "Solo se permiten archivos no mayores a 1MB");
                }
            }
            if (ModelState.IsValid)
            {
                vm.AgregarPublicaciones.Fecha = DateTime.Now;
                Publicaciones publicaciones = new()
                {
                    Texto = vm.AgregarPublicaciones.Texto,
                    Fecha = vm.AgregarPublicaciones.Fecha

                };
                Repo.PublicacionesRepository.InsertPublicacion(publicaciones,vm.AgregarPublicaciones.UserId);
                if (vm.AgregarPublicaciones.Archivo != null)
                {

                    System.IO.FileStream fs = System.IO.File.Create($"wwwroot/publicaciones/{publicaciones.Id}.png");
                    vm.AgregarPublicaciones.Archivo.CopyTo(fs);
                    fs.Close();
                }

                return RedirectToAction("Index");
            }
            return View(vm);
        }
    }
}
