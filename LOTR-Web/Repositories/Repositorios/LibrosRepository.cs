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

        public void DeleteLibro(Libros libros)
        {
            base.Delete(libros);
        }

        public IEnumerable<Libros> GetAll()
        {
            return _context.Libros.OrderBy(x => x.Nombre);
        }

        public Libros GetLibro(int id)
        {
            return _context.Libros.Where(x => x.Id == id).First();
        }

        public void InsertLibro(Libros libro)
        {
            base.Insert(libro);
        }

        public void UpdateLibro(Libros libro)
        {
            base.Update(libro);
        }
    }
}
