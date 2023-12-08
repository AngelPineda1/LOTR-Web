namespace LOTR_Web.Models.ViewModels
{
    public class LibrosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public string Editorial { get; set; } = null!;

        public DateTime FechaPublicacion { get; set; }

        public string TiendaOficial { get; set; } = null!;
    }
}
