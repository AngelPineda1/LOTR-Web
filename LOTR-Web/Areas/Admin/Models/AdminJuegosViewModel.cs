﻿namespace LOTR_Web.Areas.Admin.Models
{
    public class AdminJuegosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public DateTime FechaPublicacion { get; set; }

        public string Descripcion { get; set; } = null!;

        public string Clasificacion { get; set; } = null!;

        public int IdUsuario { get; set; }

        public int IdEstudio { get; set; }
        
    }
   
}
