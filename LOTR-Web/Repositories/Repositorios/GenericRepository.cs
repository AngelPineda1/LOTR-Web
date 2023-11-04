using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;

namespace LOTR_Web.Repositories.Repositorios
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LotrdbContext _context;
        public GenericRepository(LotrdbContext context)
        {
            _context = context;
        }
        public void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public void Edit(T obj)
        {
            _context.Set<T>().Update(obj);
            _context.SaveChanges();
        }


        public T GetById(int Id)
        {
            return _context.Set<T>().Find(Id)!;
        }

        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Set<T>().Update(obj);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll(T obj)
        {
            return _context.Set<T>().AsEnumerable();
        }
    }
}
