using LOTR_Web.Areas.Admin.Models;
using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;
using LOTR_Web.Repositories.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LOTR_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LibrosController : Controller
    {
        public IRepo _repo { get; }

        public LibrosController(IRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Agregar()
        {
            AdminLibrosViewModel model = new AdminLibrosViewModel();
            model.Autor = _repo.AutorRepository.GetAllAutores().Select(x => new AutorModel()
            {
                Id = x.Id,
                Nombre = x.Nombre?? ""
            }) ;
            return View(model);
        }
        [HttpPost]
        public IActionResult Agregar(AdminLibrosViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Libros.Nombre))
            {
                ModelState.AddModelError("", "Escriba el nombre del libro");
            }
            if (string.IsNullOrWhiteSpace(model.Libros.Descripcion))
            {
                ModelState.AddModelError("", "Escriba la descripcion del libro");
            }
            //if (string.IsNullOrWhiteSpace(libros.Editorial))
            //{
            //    ModelState.AddModelError("", "Escriba la editorial del libro");
            //}
            if (string.IsNullOrWhiteSpace(model.Libros.TiendaOficial))
            {
                ModelState.AddModelError("", "Escriba la tienda oficial");
            }
            //if (libros.FechaPublicacion == DateTime.MinValue)
            //{
            //    ModelState.AddModelError("", "Ingrese la fecha de publicacion");
            //}
            
            if (ModelState.IsValid)
            {
                
                model.Libros.IdUsuario = 1;
                model.Libros.FechaPublicacion = DateTime.Now;
                Libros x = new Libros()
                {
                    Nombre = model.Libros.Nombre,
                    Descripcion = model.Libros.Descripcion,
                    IdAutor = model.Libros.IdAutor,
                    IdUsuario= model.Libros.IdUsuario,
                    FechaPublicacion = model.Libros.FechaPublicacion,
                    Editorial= model.Libros.Editorial,
                    TiendaOficial= model.Libros.TiendaOficial
                };

                _repo.LibrosRepository.InsertLibro(x);
                return RedirectToAction("Index");
            }
            model.Autor = _repo.AutorRepository.GetAllAutores().Select(x => new AutorModel()
            {
                Id = x.Id,
                Nombre = x.Nombre ?? ""
            });
            return View(model);
        }
        //public IActionResult Editar(int id)
        //{
        //    var datos = Repo.PublicacionesRepository.GetPublicacionById(id);
        //    if (datos == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {

        //        return View(datos);
        //    }

        //}

        //[HttpPost]
        //public IActionResult Editar(Publicaciones p)
        //{
        //    if (string.IsNullOrWhiteSpace(p.Texto))
        //    {
        //        ModelState.AddModelError("", "Escriba el texto de la publicacion");
        //    }
        //    else
        //    {

        //        if (ModelState.IsValid)
        //        {
        //            var datos = Repo.PublicacionesRepository.GetPublicacionById(p.Id);

        //            if (datos == null)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //            datos.Fecha = p.Fecha;
        //            datos.Texto = p.Texto;
        //            Repo.PublicacionesRepository.UpdatePublicacion(datos);
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return View(p);
        //}
        //public IActionResult Eliminar(int id)
        //{
        //    var datos = Repo.PublicacionesRepository.GetPublicacionById(id);
        //    if (datos == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {

        //        return View(datos);
        //    }
        //}
        //[HttpPost]
        //public IActionResult Eliminar(Publicaciones p)
        //{
        //    var datos = Repo.PublicacionesRepository.GetPublicacionById(p.Id);
        //    if (datos == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    Repo.PublicacionesRepository.DeletePublicacion(datos);
        //    return RedirectToAction("Index");
        //}
    }
}
