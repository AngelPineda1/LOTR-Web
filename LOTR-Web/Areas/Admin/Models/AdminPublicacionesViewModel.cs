namespace LOTR_Web.Areas.Admin.Models
{
    public class AdminPublicacionesViewModel
    {
        public IEnumerable<PublicacionesModel>? Publicaciones { get; set;}
        public AgregarPublicacionesModel AgregarPublicaciones { get; set;}
    }
    public class PublicacionesModel
    {
        public int Id { get; set; }

        public string Texto { get; set; } = null!;

        public DateTime Fecha { get; set; }
        public bool Archivo { get; set; }
    }
    public class AgregarPublicacionesModel
    {
        public int Id { get; set; }

        public string Texto { get; set; } = null!;

        public DateTime Fecha { get; set; }
        public IFormFile? Archivo { get; set; }
    }
}
