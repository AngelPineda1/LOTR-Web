using LOTR_Web.Repositories.Intefaces;

namespace LOTR_Web.Repositories.Repositorios
{
    public class Repo:IRepo
    {
        public Repo(IAutorRepository autorRepository,IUsuarioRepository UserRepository, IPublicacionesRepository PubRepository, IPeliculasRepository peliculasRepository,ILibrosRepository librosRepository,IEstudiosRepository estudiosRepository)
        {
            AutorRepository = autorRepository;
            UsuarioRepository = UserRepository;
            PublicacionesRepository = PubRepository;
            PeliculasRepository = peliculasRepository;
            EstudiosRepository = estudiosRepository;
            LibrosRepository = librosRepository;
        }

        public IAutorRepository AutorRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }
        public IPublicacionesRepository PublicacionesRepository { get; }
        public IPeliculasRepository PeliculasRepository { get; }
        public IEstudiosRepository EstudiosRepository { get; }

        public ILibrosRepository LibrosRepository { get; }
    }
}
