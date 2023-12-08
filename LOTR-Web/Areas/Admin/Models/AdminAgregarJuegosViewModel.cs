using LOTR_Web.Models.Entities;

namespace LOTR_Web.Areas.Admin.Models
{
    public class AdminAgregarJuegosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public DateTime FechaPublicacion { get; set; }

        public string Descripcion { get; set; } = null!;

        public string Clasificacion { get; set; } = null!;

        public int IdUsuario { get; set; }

        public int IdEstudio { get; set; }
        public IEnumerable<EstudiosJuegosModel> Estudios { get; set; }
        public IFormFile? Archivo { get; set; }
    }
    public class EstudiosJuegosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
