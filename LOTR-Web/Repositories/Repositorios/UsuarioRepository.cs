using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;
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
            return _context.Usuariorol.Any(x => x.IdUsuario == Id && x.IdRol == 1);
        }
    }
}
