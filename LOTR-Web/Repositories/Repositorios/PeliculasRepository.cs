using LOTR_Web.Areas.Admin.Models;
using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace LOTR_Web.Repositories.Repositorios
{
    public class PeliculasRepository : GenericRepository<Peliculas>, IPeliculasRepository
    {
        public PeliculasRepository(LotrdbContext context) : base(context)
        {
            _context = context;
        }

        public LotrdbContext _context { get; }

        public IEnumerable<Peliculas> GetPeliculas()
        {
            IEnumerable<Peliculas> peliculas = _context.Peliculas.OrderBy(x => x.Nombre).Include(x => x.IdEstudioNavigation).Include(x => x.IdUsuarioNavigation);
            return peliculas;
        }

        public void InsertPelicula(Peliculas p)
        {
            base.Insert(p);
        }
        public Peliculas GetId(int id)
        {
            return base.GetById(id);
        }
        public void UpdatePelicula(Peliculas p)
        {
            base.Update(p);
        }
        public void DeletePelicula(Peliculas p)
        {
            base.Delete(p);
        }

        public Peliculas GetPeliculaByNombre(string id)
        {
            return _context.Peliculas.Where(x => x.Nombre == id).First(); 
        }
    }
}
