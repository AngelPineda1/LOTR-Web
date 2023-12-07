using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;

namespace LOTR_Web.Repositories.Repositorios
{
    public class LibrosRepository : GenericRepository<Libros>, ILibrosRepository
    {
        public LibrosRepository(LotrdbContext context) : base(context)
        {
            _context = context;
        }

        public LotrdbContext _context { get; }
        public void InsertLibro(Libros libro)
        {
            base.Insert(libro);
        }
    }
}
