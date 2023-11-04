using LOTR_Web.Repositories.Intefaces;

namespace LOTR_Web.Repositories.Repositorios
{
    public class Repo:IRepo
    {
        public Repo(IUsuarioRepository UserRepository, IPublicacionesRepository PubRepository)
        {
            UsuarioRepository = UserRepository;
            PublicacionesRepository = PubRepository;
        }
        public IUsuarioRepository UsuarioRepository { get; }
        public IPublicacionesRepository PublicacionesRepository { get; }
    }
}
