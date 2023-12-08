namespace LOTR_Web.Models.ViewModels
{
    public class PeliculasViewModelAnonimo
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public DateTime FechaPublicacion { get; set; }

        public string Descripcion { get; set; } = null!;
    }
}
