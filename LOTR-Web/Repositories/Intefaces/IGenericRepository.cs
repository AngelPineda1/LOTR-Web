namespace LOTR_Web.Repositories.Intefaces
{
    public interface IGenericRepository<T>
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        IEnumerable<T> GetAll(T obj);
        T GetById(int Id);
    }
}
