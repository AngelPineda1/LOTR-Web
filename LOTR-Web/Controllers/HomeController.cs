using LOTR_Web.Models.Entities;
using LOTR_Web.Models.ViewModels;
using LOTR_Web.Repositories.Intefaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public IActionResult Registrarse() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrarse(RegistrarseViewModel vm)
        {
            if (vm == null) 
            {
                ModelState.AddModelError("", "No proporcionaste ningun dato");
            }
            if (string.IsNullOrEmpty(vm.Correo))
            {
                ModelState.AddModelError("","No proporcionaste un correo válido");
            }
            if (string.IsNullOrEmpty(vm.Contraseña))
            {
                ModelState.AddModelError("", "No proporcionaste una contraseña válida");
            }
            if (string.IsNullOrEmpty(vm.Nombre))
            {
                ModelState.AddModelError("", "No proporcionaste un nombre válido");
            }
            if (vm.Foto != null)
            {
                //MIME TYPE
                if (vm.Foto.ContentType != "image/png")
                {
                    ModelState.AddModelError("", "Solo se permiten imagenes PNG");
                }
                if (vm.Foto.Length > 500 * 1024)
                {
                    ModelState.AddModelError("", "Solo se permiten archivos no mayores a 500KB");
                }
            }
            
            if (ModelState.IsValid)
            {
                Usuario? User = _repo.UsuarioRepository.RegistrarUsuario(vm);
                if (User == null)
                {
                    ModelState.AddModelError("","Este usuario ya existe");
                    return View();
                }
                bool Admin = _repo.UsuarioRepository.EsAdmin(User.Id);
                var Claims = new List<Claim>
                    {
                        new("Id",User.Id.ToString()),
                        new(ClaimTypes.Name,User.IdInfoNavigation.Nombre),
                        new(ClaimTypes.Role, Admin ? "Admin" : "User")
                    };
                var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(Identity));
                if (vm.Foto == null)
                {
                    //obtener id del producto
                    //copiar el archivo no disponible y cambiar el nombre por el id

                    System.IO.File.Copy("wwwroot/img/imagen-no-disponible.png", $"wwwroot/profpics/{User.Id}.png");
                }
                else
                {
                    System.IO.FileStream fs = System.IO.File.Create($"wwwroot/profpics/{User.Id}.png");
                    vm.Foto.CopyTo(fs);
                    fs.Close();
                }
                if (Admin)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "User" });

                }

            }
            return View();

        }
        public IActionResult Login() 
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {
            if (vm == null)
            {
                ModelState.AddModelError("", "No proporcionaste ningun dato");
                return View();
            }
            if (string.IsNullOrEmpty(vm.Correo))
            {
                ModelState.AddModelError(string.Empty, "El campo correo es obligatorio");
            }
            if (string.IsNullOrEmpty(vm.Contraseña))
            {
                ModelState.AddModelError(string.Empty, "El campo Contraseña es obligatorio");

            }
            if (ModelState.IsValid)
            {
                Usuario? User = _repo.UsuarioRepository.UsuarioLogin(vm.Correo,vm.Contraseña);
                if (User == null)
                {
                    ModelState.AddModelError(string.Empty, "Credenciales erroneas o este usuario no existe");
                }
                else 
                {
                    bool Admin = _repo.UsuarioRepository.EsAdmin(User.Id);
                    var Claims = new List<Claim>
                    {
                        new("Id",User.Id.ToString()),
                        new(ClaimTypes.Name,User.Correo),
                        new(ClaimTypes.Role, Admin ? "Admin" : "User")
                    };
                    var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(Identity));
                    if (Admin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else 
                    {
                        return RedirectToAction("Index","Home",new {area = "User"});
                    
                    }
                }
            }

            return View();

        }
        public IActionResult LogOut() 
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
        public IActionResult Peliculas()
        {
            return View();
        }
    }
}
