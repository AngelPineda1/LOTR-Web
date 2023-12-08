namespace LOTR_Web.Models.ViewModels
{
    public class RegistrarseViewModel
    {
        public string Correo { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public IFormFile Foto {get;set;} 
    }
}
