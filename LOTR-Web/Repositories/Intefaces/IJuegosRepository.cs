using LOTR_Web.Models.Entities;

namespace LOTR_Web.Repositories.Intefaces
{
    public interface IJuegosRepository
    {
        IEnumerable<Juegos> GetJuegos();
        void InsertJuego(Juegos juegos);
        void UpdateJuego(Juegos juegos);
        void DeleteJuego(Juegos juegos);
        Juegos GetJuegoById(int id);
        Juegos GetJuegosByNombre(string nombre);
    }
}
