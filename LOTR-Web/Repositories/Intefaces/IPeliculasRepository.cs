using LOTR_Web.Areas.Admin.Models;
using LOTR_Web.Models.Entities;

namespace LOTR_Web.Repositories.Intefaces
{
    public interface IPeliculasRepository
    {
        IEnumerable<Peliculas> GetPeliculas();
        void InsertPelicula(Peliculas p);
        Peliculas GetId(int id);
        void UpdatePelicula(Peliculas p);
        void DeletePelicula(Peliculas p);
        Peliculas GetPeliculaByNombre(string id);
    }
}
