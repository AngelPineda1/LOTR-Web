using LOTR_Web.Areas.Admin.Models;
using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;
using LOTR_Web.Repositories.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LOTR_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LibrosController : Controller
    {
        public IRepo _repo { get; }

        public LibrosController(IRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var datos=_repo.LibrosRepository.GetAll().Select(x=>new LibrosViewModel()
            {
                Id = x.Id,
                Nombre = x.Nombre,
            });
           
            
            return View(datos);
        }
        public IActionResult VerDetalles(int id)
        {
            var datos = _repo.LibrosRepository.GetLibro(id);
            return View(datos);
        }
        public IActionResult Agregar()
        {
            AdminLibrosViewModel vm= new AdminLibrosViewModel();
            vm.Autor = _repo.AutorRepository.GetAllAutores().Select(x => new AutorModel()
            {
                Id = x.Id,
                Nombre = x.Nombre?? ""
            }) ;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Agregar(AdminLibrosViewModel vm)
        {
            if (string.IsNullOrWhiteSpace(vm.Libros.Nombre))
            {
                ModelState.AddModelError("", "Escriba el nombre del libro");
            }
            if (string.IsNullOrWhiteSpace(vm.Libros.Descripcion))
            {
                ModelState.AddModelError("", "Escriba la descripcion del libro");
            }
            //if (string.IsNullOrWhiteSpace(libros.Editorial))
            //{
            //    ModelState.AddModelError("", "Escriba la editorial del libro");
            //}
            if (string.IsNullOrWhiteSpace(vm.Libros.TiendaOficial))
            {
                ModelState.AddModelError("", "Escriba la tienda oficial");
            }
            if (vm.Libros.FechaPublicacion == DateTime.MinValue)
            {
                ModelState.AddModelError("", "Ingrese la fecha de publicacion");
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
                
                vm.Libros.IdUsuario = 1;
                
                Libros x = new Libros()
                {
                    Nombre = vm.Libros.Nombre,
                    Descripcion = vm.Libros.Descripcion,
                    IdAutor = vm.Libros.IdAutor,
                    IdUsuario= vm.Libros.IdUsuario,
                    FechaPublicacion = vm.Libros.FechaPublicacion,
                    Editorial= vm.Libros.Editorial,
                    TiendaOficial= vm.Libros.TiendaOficial
                };

                _repo.LibrosRepository.InsertLibro(x);
                if (vm.Archivo == null)
                {
                    //obtener id del producto
                    //copiar el archivo no disponible y cambiar el nombre por el id

                    System.IO.File.Copy("wwwroot/img/imagen-no-disponible.png", $"wwwroot/libros/{x.Id}.png");
                }
                else
                {
                    System.IO.FileStream fs = System.IO.File.Create($"wwwroot/libros/{x.Id}.png");
                    vm.Archivo.CopyTo(fs);
                    fs.Close();
                }
                return RedirectToAction("Index");
            }
            vm.Autor = _repo.AutorRepository.GetAllAutores().Select(x => new AutorModel()
            {
                Id = x.Id,
                Nombre = x.Nombre ?? ""
            });
            return View(vm);
        }
        public IActionResult Editar(int id)
        {
            AdminLibrosViewModel vm = new();
            var datos = _repo.LibrosRepository.GetLibro(id);
            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                vm.Libros = new LibrosModel();
                vm.Libros.TiendaOficial = datos.TiendaOficial;
                vm.Libros.Editorial = datos.Editorial;
                vm.Libros.Nombre = datos.Nombre;
                vm.Libros.Descripcion = datos.Descripcion;
                vm.Libros.IdAutor = datos.IdAutor;
                vm.Libros.Id=datos.Id;
                vm.Libros.FechaPublicacion = datos.FechaPublicacion;
                vm.Autor= _repo.AutorRepository.GetAllAutores().Select(x => new AutorModel()
                {
                    Id = x.Id,
                    Nombre = x.Nombre ?? ""
                });
                return View(vm);
            }

        }

        [HttpPost]
        public IActionResult Editar(AdminLibrosViewModel vm)
        {
            if (string.IsNullOrWhiteSpace(vm.Libros.Nombre))
            {
                ModelState.AddModelError("", "Escriba el nombre del libro");
            }
            if (string.IsNullOrWhiteSpace(vm.Libros.Descripcion))
            {
                ModelState.AddModelError("", "Escriba la descripcion del libro");
            }
            //if (string.IsNullOrWhiteSpace(libros.Editorial))
            //{
            //    ModelState.AddModelError("", "Escriba la editorial del libro");
            //}
            if (string.IsNullOrWhiteSpace(vm.Libros.TiendaOficial))
            {
                ModelState.AddModelError("", "Escriba la tienda oficial");
            }
            if (vm.Libros.FechaPublicacion == DateTime.MinValue)
            {
                ModelState.AddModelError("", "Ingrese la fecha de publicacion");
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

                
                var datos = _repo.LibrosRepository.GetLibro(vm.Libros.Id);
                if (datos == null)
                {
                    return RedirectToAction("Index");
                }
                datos.TiendaOficial = vm.Libros.TiendaOficial;
                datos.Editorial = vm.Libros.Editorial;
                datos.Nombre = vm.Libros.Nombre;
                datos.Descripcion = vm.Libros.Descripcion;
                datos.IdAutor = vm.Libros.IdAutor;
                datos.FechaPublicacion = vm.Libros.FechaPublicacion;
                
                _repo.LibrosRepository.UpdateLibro(datos);
                if (vm.Archivo != null)
                {

                    System.IO.FileStream fs = System.IO.File.Create($"wwwroot/Libros/{vm.Libros.Id}.png");
                    vm.Archivo.CopyTo(fs);
                    fs.Close();
                }

                return RedirectToAction("Index");
            }
            vm.Autor = _repo.AutorRepository.GetAllAutores().Select(x => new AutorModel()
            {
                Id = x.Id,
                Nombre = x.Nombre ?? ""
            });
            return View(vm);
        }
        public IActionResult Eliminar(int id)
        {
            var datos = _repo.LibrosRepository.GetLibro(id);
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
        public IActionResult Eliminar(Libros l)
        {
            var datos = _repo.LibrosRepository.GetLibro(l.Id);
            if (datos == null)
            {
                return RedirectToAction("Index");
            }
            _repo.LibrosRepository.DeleteLibro(datos);
            var ruta = $"wwwroot/Libros/{l.Id}.png";
            if (System.IO.File.Exists(ruta))
            {
                System.IO.File.Delete(ruta);
            }
            return RedirectToAction("Index");
            
        }
    }
}
