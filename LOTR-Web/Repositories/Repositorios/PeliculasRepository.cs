using LOTR_Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LOTR_Web.Repositories.Repositorios
{
    public class PeliculasRepository : GenericRepository<Peliculas>
    {
        private readonly LotrdbContext _context;

        public PeliculasRepository(LotrdbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Peliculas> GetPeliculas() {
            return _context.Peliculas.OrderBy(x=>x.Nombre).Include(x=>x.IdEstudioNavigation).Include(x=>x.IdUsuarioNavigation);
        }
    }
}
