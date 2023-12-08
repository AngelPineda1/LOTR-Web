namespace LOTR_Web.Models.ViewModels
{
    public class ForoViewModel
    {
        public int Id { get; set; }

        public string Texto { get; set; } = null!;

        public DateTime Fecha { get; set; }
        public bool Archivo { get; set; }
    }
}
