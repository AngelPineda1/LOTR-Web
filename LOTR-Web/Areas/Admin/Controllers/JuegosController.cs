using LOTR_Web.Areas.Admin.Models;
using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.RegularExpressions;

namespace LOTR_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JuegosController : Controller
    {
        public JuegosController(IRepo repo)
        {
            _repo = repo;
        }

        public IRepo _repo { get; }

        public IActionResult Index()
        {
            var datos=_repo.JuegosRepository.GetJuegos().Select(x=> new AdminJuegosViewModel()
            {
               Id = x.Id,
               IdEstudio = x.IdEstudio,
               IdUsuario = x.IdUsuario,
               Nombre = x.Nombre,
               Descripcion = x.Descripcion,
               FechaPublicacion = x.FechaPublicacion,
               Clasificacion = x.Clasificacion,
            });
            return View(datos);
        }
        public IActionResult Agregar() {
            AdminAgregarJuegosViewModel vm = new AdminAgregarJuegosViewModel();
            vm.Estudios = _repo.EstudiosRepository.GetAll().Select(x => new EstudiosJuegosModel()
            {
                Id = x.Id,
                Nombre = x.Nombre,
            });
            return View(vm);
        }
        [HttpPost]
        public IActionResult Agregar(AdminAgregarJuegosViewModel vm)
        {
            if(string.IsNullOrWhiteSpace(vm.Nombre))
            {
                ModelState.AddModelError("", "Debe ingresar el nombre del juego.");
            }
            if (string.IsNullOrWhiteSpace(vm.Descripcion))
            {
                ModelState.AddModelError("", "Debe ingresar la descripcion del juego.");
            }
            if (string.IsNullOrWhiteSpace(vm.Clasificacion))
            {
                ModelState.AddModelError("", "Debe ingresar la clasificacion del juego.");
            }
            if(vm.FechaPublicacion==DateTime.MinValue)
            {
                ModelState.AddModelError("", "Debe ingresar la fecha de publicacion del juego.");
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
            if(!ModelState.IsValid)
            {
                vm.IdUsuario = 1;
                Juegos x= new Juegos()
                {
                    Nombre= vm.Nombre,
                    Descripcion= vm.Descripcion,
                    Clasificacion   = vm.Clasificacion,
                    FechaPublicacion = vm.FechaPublicacion,
                    IdEstudio= vm.IdEstudio,
                    IdUsuario= vm.IdUsuario,
                };
                _repo.JuegosRepository.InsertJuego(x);
                if (vm.Archivo == null)
                {
                    //obtener id del producto
                    //copiar el archivo no disponible y cambiar el nombre por el id

                    System.IO.File.Copy("wwwroot/img/imagen-no-disponible.png", $"wwwroot/Juegos/{x.Id}.png");
                }
                else
                {
                    System.IO.FileStream fs = System.IO.File.Create($"wwwroot/Juegos/{x.Id}.png");
                    vm.Archivo.CopyTo(fs);
                    fs.Close();
                }
                return RedirectToAction("Index");
            }
            vm.Estudios = _repo.EstudiosRepository.GetAll().Select(x => new EstudiosJuegosModel()
            {
                Id = x.Id,
                Nombre = x.Nombre,
            });
            return View(vm);
        }
        public IActionResult Editar(int id)
        {
            AdminAgregarJuegosViewModel vm = new();
            var datos=_repo.JuegosRepository.GetJuegoById(id);
            if(datos == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                vm.FechaPublicacion = datos.FechaPublicacion;
                vm.Nombre = datos.Nombre;
                vm.Descripcion = datos.Descripcion;
                vm.Clasificacion = datos.Clasificacion;
                vm.IdEstudio = datos.IdEstudio;
                vm.Id=datos.Id;
                vm.Estudios = _repo.EstudiosRepository.GetAll().Select(x => new EstudiosJuegosModel() { Id = x.Id, Nombre = x.Nombre, });

            return View(vm);
            }
        }
        [HttpPost]
        public IActionResult Editar(AdminAgregarJuegosViewModel vm)
        {


            if (string.IsNullOrWhiteSpace(vm.Nombre))
            {
                ModelState.AddModelError("", "Debe ingresar el nombre del juego.");
            }
            if (string.IsNullOrWhiteSpace(vm.Descripcion))
            {
                ModelState.AddModelError("", "Debe ingresar la descripcion del juego.");
            }
            if (string.IsNullOrWhiteSpace(vm.Clasificacion))
            {
                ModelState.AddModelError("", "Debe ingresar la clasificacion del juego.");
            }
            if (vm.FechaPublicacion == DateTime.MinValue)
            {
                ModelState.AddModelError("", "Debe ingresar la fecha de publicacion del juego.");
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
            if (!ModelState.IsValid)
            {
                var datos = _repo.JuegosRepository.GetJuegoById(vm.Id);
                if (datos == null)
                {
                    return RedirectToAction("Index");
                }

                datos.Descripcion = vm.Descripcion;
                datos.Clasificacion = vm.Clasificacion;
                datos.FechaPublicacion = vm.FechaPublicacion;
                datos.Nombre = vm.Nombre;
                datos.IdEstudio = vm.IdEstudio;


                _repo.JuegosRepository.UpdateJuego(datos);
                if (vm.Archivo != null)
                {

                    System.IO.FileStream fs = System.IO.File.Create($"wwwroot/Juegos/{datos.Id}.png");
                    vm.Archivo.CopyTo(fs);
                    fs.Close();
                }
                return RedirectToAction("Index");
            }
            vm.Estudios = _repo.EstudiosRepository.GetAll().Select(x => new EstudiosJuegosModel()
            {
                Id = x.Id,
                Nombre = x.Nombre,
            });
            return View(vm);
        }
        public IActionResult Eliminar(int id)
        {
            var datos=_repo.JuegosRepository.GetJuegoById(id);
            return View(datos);
        }
        [HttpPost]
        public IActionResult Eliminar(Juegos juegos)
        {
            var datos = _repo.JuegosRepository.GetJuegoById(juegos.Id);
            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            _repo.JuegosRepository.DeleteJuego(datos);
            var ruta = $"wwwroot/Juegos/{juegos.Id}.png";
            if (System.IO.File.Exists(ruta))
            {
                System.IO.File.Delete(ruta);
            }
            return RedirectToAction("Index");
        }
    }
}
