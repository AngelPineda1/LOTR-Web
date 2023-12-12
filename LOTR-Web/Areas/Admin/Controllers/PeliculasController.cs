using LOTR_Web.Areas.Admin.Models;
using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;
using LOTR_Web.Repositories.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace LOTR_Web.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = "Admin")]
    public class PeliculasController : Controller
    {
        private readonly IRepo _repo;

        public PeliculasController(IRepo repo)
        {
            
            _repo = repo;
        }
        public IActionResult Index()
        {
            var datos=_repo.PeliculasRepository.GetPeliculas().Select(x=> new PeliculasViewModel()
            {
                Nombre = x.Nombre,
                Id = x.Id,
                Descripcion=x.Descripcion,
                NombreEstudio=x.IdEstudioNavigation.Nombre,
                NombreUsuario=x.IdUsuarioNavigation.Correo,
                FechaPublicacion=x.FechaPublicacion
                

            });
            
            return View(datos);
        }
        public IActionResult Agregar()
        {
            AdminPeliculasViewModel vm = new AdminPeliculasViewModel();

            vm.Estudios = _repo.EstudiosRepository.GetAll().Select(x => new EstudiosModel()
            {
                Id = x.Id,
                Nombre = x.Nombre,
            });

            return View(vm);
        }
        [HttpPost]
        public IActionResult Agregar(AdminPeliculasViewModel vm)
        {
            if (string.IsNullOrWhiteSpace(vm.Peliculas.Nombre))
            {
                ModelState.AddModelError("", "Debe ingresar el nombre de la pelicula");
            }
            if (string.IsNullOrWhiteSpace(vm.Peliculas.Descripcion))
            {
                ModelState.AddModelError("", "Debe ingresar la descripcion de la pelicula");
            }
            if (vm.Peliculas.FechaPublicacion == DateTime.MinValue)
            {
                ModelState.AddModelError("", "Debe ingresar la fecha de publicacion de la pelicula");
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

                Peliculas peliculas = new Peliculas()
                {
                    Nombre=vm.Peliculas.Nombre,
                    IdEstudio=vm.Peliculas.IdEstudio,
                    IdUsuario=vm.Peliculas.IdUsuario,
                    Descripcion=vm.Peliculas.Descripcion,
                    FechaPublicacion=vm.Peliculas.FechaPublicacion
                };

                _repo.PeliculasRepository.InsertPelicula(peliculas);
                if (vm.Archivo == null)
                {
                    //obtener id del producto
                    //copiar el archivo no disponible y cambiar el nombre por el id

                    System.IO.File.Copy("wwwroot/Peliculas/imagen-no-disponible.png", $"wwwroot/Peliculas/{peliculas.Id}.png");
                }
                else
                {
                    System.IO.FileStream fs = System.IO.File.Create($"wwwroot/Peliculas/{peliculas.Id}.png");
                    vm.Archivo.CopyTo(fs);
                    fs.Close();
                }
                return RedirectToAction("Index");
            }
            vm.Estudios = _repo.EstudiosRepository.GetAll().Select(x => new EstudiosModel()
            {
                Id = x.Id,
                Nombre = x.Nombre,
            });
            return View(vm);
        }
        public IActionResult Editar(int id)
        {
            var datos=_repo.PeliculasRepository.GetId(id);
            if(datos == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                AdminPeliculasViewModel vm = new AdminPeliculasViewModel();
                vm.Peliculas = new PeliculasModel();
                vm.Peliculas.IdEstudio = datos.IdEstudio;
                vm.Peliculas.Nombre = datos.Nombre;
                vm.Peliculas.Descripcion = datos.Descripcion;
                vm.Peliculas.FechaPublicacion = datos.FechaPublicacion;
                vm.Peliculas.Id=datos.Id;
                vm.Estudios=_repo.EstudiosRepository.GetAll().Select(x=>new EstudiosModel()
                {
                    Id=x.Id,
                    Nombre = x.Nombre,
                });

            return View(vm);
            }
        }
        [HttpPost]
        public IActionResult Editar(AdminPeliculasViewModel vm)
        {
            if (string.IsNullOrWhiteSpace(vm.Peliculas.Nombre))
            {
                ModelState.AddModelError("", "Debe ingresar el nombre de la pelicula");
            }
            if (string.IsNullOrWhiteSpace(vm.Peliculas.Descripcion))
            {
                ModelState.AddModelError("", "Debe ingresar la descripcion de la pelicula");
            }
            if (vm.Peliculas.FechaPublicacion == DateTime.MinValue)
            {
                ModelState.AddModelError("", "Debe ingresar la fecha de publicacion de la pelicula");
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
                var datos = _repo.PeliculasRepository.GetId(vm.Peliculas.Id);
                if (datos == null)
                {
                    return RedirectToAction("Index");
                }
                
                   
                     datos.IdEstudio= vm.Peliculas.IdEstudio ;
                    datos.Nombre= vm.Peliculas.Nombre;
                    datos.Descripcion = vm.Peliculas.Descripcion;
                    datos.FechaPublicacion = DateTime.Now;

                   
                _repo.PeliculasRepository.UpdatePelicula(datos);
                if (vm.Archivo != null)
                {

                    System.IO.FileStream fs = System.IO.File.Create($"wwwroot/Hamburguesas/{vm.Peliculas.Id}.png");
                    vm.Archivo.CopyTo(fs);
                    fs.Close();
                }
                return RedirectToAction("Index");
            }
                    
            vm.Estudios = _repo.EstudiosRepository.GetAll().Select(x => new EstudiosModel()
            {
                Id = x.Id,
                Nombre = x.Nombre,
            });
            return View(vm);
        }
        public IActionResult Eliminar(int id)
        {
            var datos = _repo.PeliculasRepository.GetId(id);
            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            return View(datos);
        }
        [HttpPost]
        public IActionResult Eliminar(Peliculas p)
        {
            var peli = _repo.PeliculasRepository.GetId(p.Id);
            if (peli == null)
            {
                return RedirectToAction("Index");
            }
            _repo.PeliculasRepository.DeletePelicula(peli);
            var ruta = $"wwwroot/Peliculas/{p.Id}.png";
            if (System.IO.File.Exists(ruta))
            {
                System.IO.File.Delete(ruta);
            }
            return RedirectToAction("Index");
            
        }

    }
}
