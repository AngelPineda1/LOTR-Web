using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace LOTR_Web.Controllers
{
    public class HomeController : Controller
    {
        /*Esta interfaz implementará todos los repositorios*/
        private readonly IRepo _repo;
        /*Si creas un nuevo repositorio, revisa el patron de repositorio e interfaz*/
        /*Una vez creado el nuevo repositorio, agregalo a la interfaz IRepo*/

        public HomeController(IRepo repo)
        {

            _repo = repo;

        }
        public IActionResult Index()
        {
            /*Ejemplo*/

            //Publicaciones Publicacion = _repo.PublicacionesRepository.GetPublicacionById(1);
            //Usuario User = _repo.UsuarioRepository.GetUsuarioById(1);

            return View();
        }
    }
}
