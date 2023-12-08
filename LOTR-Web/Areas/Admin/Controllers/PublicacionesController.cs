using LOTR_Web.Areas.Admin.Models;
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
            var datos = new AdminPublicacionesViewModel()
            {
                Publicaciones = Repo.PublicacionesRepository.GetPublicaciones().Select(x => new PublicacionesModel()
                {

                    Id = x.Id,
                    Fecha = x.Fecha,
                    Texto = x.Texto,
                    Archivo = existeFoto(x.Id)
                }),
                AgregarPublicaciones = new AgregarPublicacionesModel()
            };
            
            return View(datos);
        }
        [HttpPost]
        public IActionResult Index(AdminPublicacionesViewModel vm)
        {
           
            vm.Publicaciones = Repo.PublicacionesRepository.GetPublicaciones().Select(x => new PublicacionesModel()
            {

                Id = x.Id,
                Fecha = x.Fecha,
                Texto = x.Texto,
                Archivo = existeFoto(x.Id)
            });
           
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
                if (vm.AgregarPublicaciones.Archivo.Length > 500 * 1024)
                {
                    ModelState.AddModelError("", "Solo se permiten archivos no mayores a 500KB");
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
                Repo.PublicacionesRepository.InsertPublicacion(publicaciones);
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
       
        public IActionResult Editar(int id)
        {
            var datos=Repo.PublicacionesRepository.GetPublicacionById(id);
            if(datos == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                AdminAgregarPublicacionesViewModel vm = new()
                {
                    Id = datos.Id,
                    Texto = datos.Texto,
                    Fecha = datos.Fecha,
                    existe = existeFoto(datos.Id)
                };
            return View(vm);
            }

        }

        [HttpPost]
        public IActionResult Editar(AdminAgregarPublicacionesViewModel vm)
        {
            if (string.IsNullOrWhiteSpace(vm.Texto))
            {
                    ModelState.AddModelError("", "Escriba el texto de la publicacion");
            }
            if (vm.Archivo != null)
            {
                //MIME TYPE
                if (vm.Archivo.ContentType != "image/png")
                {
                    ModelState.AddModelError("", "Solo se permiten imagenes PNG");
                }
                if (vm.Archivo.Length > 500 * 1024)
                {
                    ModelState.AddModelError("", "Solo se permiten archivos no mayores a 500KB");
                }
            }

            if (ModelState.IsValid)
                {
                    var datos = Repo.PublicacionesRepository.GetPublicacionById(vm.Id);

                    if(datos == null)
                    {
                        return RedirectToAction("Index");
                    }
                    datos.Fecha = DateTime.Now;
                    datos.Texto = vm.Texto;
                    Repo.PublicacionesRepository.UpdatePublicacion(datos);
                if (vm.Archivo != null)
                {

                    System.IO.FileStream fs = System.IO.File.Create($"wwwroot/Publicaciones/{datos.Id}.png");
                    vm.Archivo.CopyTo(fs);
                    fs.Close();
                }
                return RedirectToAction("Index");
                }
            
            return View(vm);
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
            var ruta = $"wwwroot/Publicaciones/{p.Id}.png";
            if (System.IO.File.Exists(ruta))
            {
                System.IO.File.Delete(ruta);
            }
            return RedirectToAction("Index");
        }
    }
}
