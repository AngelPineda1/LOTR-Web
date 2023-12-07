using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;

namespace LOTR_Web.Repositories.Repositorios
{
    public class AutorRepository : GenericRepository<Autor>, IAutorRepository
    {
        public AutorRepository(LotrdbContext context) : base(context)
        {
            Context = context;
        }

        public LotrdbContext Context { get; }

        public IEnumerable<Autor> GetAllAutores()
        {
            return Context.Autor.OrderBy(x => x.Nombre);
        }
    }
}
