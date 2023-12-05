using LOTR_Web.Areas.Admin.Models;
using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LOTR_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PeliculasController : Controller
    {
        private readonly PeliculasRepository _peliculasRepository;
        private readonly EstudiosRepository _repoEstudio;

        public PeliculasController(PeliculasRepository peliculasRepository,EstudiosRepository repoEstudio)
        {
            _peliculasRepository = peliculasRepository;
            _repoEstudio = repoEstudio;
        }
        public IActionResult Index()
        {
            var datos=_peliculasRepository.GetPeliculas().Select(x=> new PeliculasViewModel()
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
            AdminPeliculasViewModel vm=new AdminPeliculasViewModel();
            
            vm.Estudios=_repoEstudio.GetAll(Peliculas).Select(x=>new EstudiosModel()
            {
                Id=x.Id,
                Nombre=x.Nombre,
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

            if (ModelState.IsValid)
            {
                _peliculasRepository.Insert(vm);
            }
            return View(); 
        }
        public IActionResult Editar(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Editar(AdminPeliculasViewModel vm)
        {
            return View();
        }
        public IActionResult Eliminar(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(Peliculas p)
        {
            return View();
        }

    }
}
