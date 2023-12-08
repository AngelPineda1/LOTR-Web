using LOTR_Web.Models.Entities;
using LOTR_Web.Models.ViewModels;

namespace LOTR_Web.Repositories.Intefaces
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuarioById(int Id);
        Usuario? UsuarioLogin(string Correo, string Contraseña);
        bool EsAdmin(int Id);
        Usuario? RegistrarUsuario(RegistrarseViewModel vm);
    }
}
