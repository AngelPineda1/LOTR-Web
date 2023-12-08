using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;

namespace LOTR_Web.Repositories.Repositorios
{
    public class JuegosRepository : GenericRepository<Juegos>, IJuegosRepository
    {
        public JuegosRepository(LotrdbContext context) : base(context)
        {
            Context = context;
        }

        public LotrdbContext Context { get; }

        public void DeleteJuego(Juegos juegos)
        {
            base.Delete(juegos);
        }

        public Juegos GetJuegoById(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Juegos> GetJuegos()
        {
            return Context.Juegos.OrderBy(x=>x.Nombre);
        }

        public void InsertJuego(Juegos juegos)
        {
            base.Insert(juegos);
        }

        public void UpdateJuego(Juegos juegos)
        {
            base.Update(juegos);
        }
    }
}
