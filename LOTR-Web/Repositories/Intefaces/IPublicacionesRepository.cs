using LOTR_Web.Models.Entities;

namespace LOTR_Web.Repositories.Intefaces
{
    public interface IPublicacionesRepository
    {
        Publicaciones GetPublicacionById(int Id);
        IEnumerable<Publicaciones> GetPublicaciones();
        void InsertPublicacion(Publicaciones p);
        void UpdatePublicacion(Publicaciones p);
        void DeletePublicacion(Publicaciones p);
    }
}
