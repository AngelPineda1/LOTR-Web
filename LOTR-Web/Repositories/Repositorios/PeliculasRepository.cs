using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace LOTR_Web.Repositories.Repositorios
{
    public class PeliculasRepository : GenericRepository<Peliculas>, IPeliculasRepository
    {
        private readonly LotrdbContext _context;

        public PeliculasRepository(LotrdbContext context) : base(context)
        {
            _context = context;
        }
        public Peliculas GetPeliculas() {
            
            return _context.Peliculas.OrderBy(x=>x.Nombre).Include(x=>x.IdEstudioNavigation).Include(x=>x.IdUsuarioNavigation);
        }
    }
}
