using LOTR_Web.Models.Entities;

namespace LOTR_Web.Repositories.Repositorios
{
    public class EstudiosRepository : GenericRepository<Estudio>
    {
        private readonly LotrdbContext _context;
        public EstudiosRepository(LotrdbContext context) : base(context)
        {
            _context=context;
        }
        public IEnumerable<Estudio> GetEstudios()
        {
            return (IEnumerable<Estudio>)_context.Peliculas.OrderBy(x=>x.Nombre);
        }
    }
}
