namespace LOTR_Web.Repositories.Intefaces
{
    public interface IRepo
    {
        IUsuarioRepository UsuarioRepository { get; }
        IPublicacionesRepository PublicacionesRepository { get; }
        IPeliculasRepository PeliculasRepository { get; }
        IEstudiosRepository EstudiosRepository { get; }
        ILibrosRepository LibrosRepository { get; }
        IAutorRepository AutorRepository { get; }
        IJuegosRepository JuegosRepository { get; }
    }
}
