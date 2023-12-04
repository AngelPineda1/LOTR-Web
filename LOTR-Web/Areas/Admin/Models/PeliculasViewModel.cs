namespace LOTR_Web.Areas.Admin.Models
{
    public class PeliculasViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public DateTime FechaPublicacion { get; set; }

        public string Descripcion { get; set; } = null!;

        public string NombreEstudio { get; set; }=null!;

        public string NombreUsuario { get; set; } = null!;

    }
}
