using LOTR_Web.Models.Entities;

namespace LOTR_Web.Repositories.Intefaces
{
    public interface IAutorRepository
    {
        IEnumerable<Autor> GetAllAutores();
    }
}
