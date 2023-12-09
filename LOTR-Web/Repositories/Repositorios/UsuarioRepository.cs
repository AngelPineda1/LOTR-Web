using LOTR_Web.Models.Entities;
using LOTR_Web.Models.ViewModels;
using LOTR_Web.Repositories.Intefaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LOTR_Web.Repositories.Repositorios
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly LotrdbContext _context;
        public UsuarioRepository(LotrdbContext context) : base(context)
        {
            _context = context;
        }

        public Usuario GetUsuarioById(int Id)
        {
            Usuario User = base.GetById(Id);
            return User;
        }
        public Usuario? UsuarioLogin(string Correo, string Contraseña) 
        {
            return _context.Usuario.FirstOrDefault(x => x.Correo == Correo && x.Contraseña == Contraseña);
        }
        public bool EsAdmin(int Id) 
        {
            return _context.Usuariorol.Any(x => x.IdUsuario == Id && x.IdRol == 2);
        }
        public Usuario? RegistrarUsuario(RegistrarseViewModel vm)
        {
            Usuario? YaExiste = _context.Usuario.FirstOrDefault(x => x.Correo == vm.Correo);
            if (YaExiste != null)
            {
                return null;
            }
            Usuarioinfo info = new()
            {
                Nombre = vm.Nombre,
                Id = 0
            };
            _context.Usuarioinfo.Add(info);
            Usuario User = new() 
            {
                Id = 0,
                Contraseña = vm.Contraseña,
                Correo = vm.Correo,
                IdInfoNavigation = info
            };
            //Insert(User);
            Insert(User);
            Usuariorol ur = new()
            {
                IdRol = 1,
                IdUsuario = User.Id
            };
            _context.Usuariorol.Add(ur);
            _context.SaveChanges();
            return GetById(User.Id);
        }
    }
}
