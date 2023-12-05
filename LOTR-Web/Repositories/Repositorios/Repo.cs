using LOTR_Web.Repositories.Intefaces;

namespace LOTR_Web.Repositories.Repositorios
{
    public class Repo:IRepo
    {
        public Repo(IUsuarioRepository UserRepository, IPublicacionesRepository PubRepository, IPeliculasRepository peliculasRepository,IEstudiosRepository estudiosRepository)
        {
            UsuarioRepository = UserRepository;
            PublicacionesRepository = PubRepository;
            PeliculasRepository = peliculasRepository;
            EstudiosRepository = estudiosRepository;
        }
        public IUsuarioRepository UsuarioRepository { get; }
        public IPublicacionesRepository PublicacionesRepository { get; }
        public IPeliculasRepository PeliculasRepository { get; }
        public IEstudiosRepository EstudiosRepository { get; }
    }
}
