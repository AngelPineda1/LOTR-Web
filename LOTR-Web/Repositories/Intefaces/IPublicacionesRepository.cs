using LOTR_Web.Areas.Admin.Models;
using LOTR_Web.Models.Entities;

namespace LOTR_Web.Repositories.Intefaces
{
    public interface IPublicacionesRepository
    {
        Publicaciones GetPublicacionById(int Id);
        AdminPublicacionesViewModel GetPublicaciones();
        void InsertPublicacion(Publicaciones p, int Id);
        void UpdatePublicacion(Publicaciones p);
        void DeletePublicacion(Publicaciones p);
    }
}
