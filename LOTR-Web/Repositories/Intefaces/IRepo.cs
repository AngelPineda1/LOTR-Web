namespace LOTR_Web.Repositories.Intefaces
{
    public interface IRepo
    {
        IUsuarioRepository UsuarioRepository { get; }
        IPublicacionesRepository PublicacionesRepository { get; }
    }
}
