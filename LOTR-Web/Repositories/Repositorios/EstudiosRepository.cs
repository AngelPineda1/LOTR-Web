using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;

namespace LOTR_Web.Repositories.Repositorios
{
    public class EstudiosRepository : GenericRepository<Estudio>, IEstudiosRepository
    {
        private readonly LotrdbContext _context;

        public EstudiosRepository(LotrdbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Estudio> GetAll()
        {
        return _context.Estudio.OrderBy(x => x.Nombre);
        }
    }
}
