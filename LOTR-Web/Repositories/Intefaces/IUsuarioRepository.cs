using LOTR_Web.Models.Entities;

namespace LOTR_Web.Repositories.Intefaces
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuarioById(int Id);
        Usuario? UsuarioLogin(string Correo, string Contraseña);
        bool EsAdmin(int Id);
    }
}
