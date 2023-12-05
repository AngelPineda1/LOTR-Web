using LOTR_Web.Models.Entities;

namespace LOTR_Web.Repositories.Intefaces
{
    public interface IEstudiosRepository
    {
        IEnumerable<Estudio> GetAll();
    }
}
