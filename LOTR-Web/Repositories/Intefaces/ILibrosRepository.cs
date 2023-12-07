using LOTR_Web.Models.Entities;

namespace LOTR_Web.Repositories.Intefaces
{
    public interface ILibrosRepository
    {
        void InsertLibro(Libros libro);
        Libros GetLibro(int id);
        void UpdateLibro(Libros libro);
        void DeleteLibro(Libros libros);
        IEnumerable<Libros> GetAll();
    }
}
