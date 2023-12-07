namespace LOTR_Web.Areas.Admin.Models
{
    public class AdminPublicacionesViewModel
    {
        public int Id { get; set; }

        public string Texto { get; set; } = null!;

        public DateTime Fecha { get; set; }
        public IFormFile? Archivo { get; set; }
    }
}
