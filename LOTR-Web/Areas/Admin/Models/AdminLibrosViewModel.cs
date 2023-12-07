namespace LOTR_Web.Areas.Admin.Models
{
    public class AdminLibrosViewModel
    {
        public LibrosModel? Libros { get; set; }
        public IEnumerable<AutorModel>? Autor { get; set; }
    }
    public class LibrosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public string Editorial { get; set; } = null!;

        public DateTime FechaPublicacion { get; set; }

        public string TiendaOficial { get; set; } = null!;

        public int IdUsuario { get; set; }

        public int IdAutor { get; set; }
    }
    public class AutorModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
