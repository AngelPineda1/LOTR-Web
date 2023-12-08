namespace LOTR_Web.Areas.Admin.Models
{
    public class AdminAgregarPublicacionesViewModel
    {
        public int Id { get; set; }

        public string Texto { get; set; } = null!;

        public DateTime Fecha { get; set; }
        public IFormFile? Archivo { get; set; }
        public bool existe {  get; set; } 
    }
}
