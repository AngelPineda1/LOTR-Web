using LOTR_Web.Models.Entities;

namespace LOTR_Web.Areas.Admin.Models
{
    public class AdminPeliculasViewModel
    {

        public PeliculasModel Peliculas { get; set; } = null!;
        public IEnumerable<EstudiosModel> Estudios { get; set; } = null!;
    }
    public class EstudiosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
    public class PeliculasModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public DateTime FechaPublicacion { get; set; }

        public string Descripcion { get; set; } = null!;

        public int IdEstudio { get; set; }

        public int IdUsuario { get; set; }
    }
}
