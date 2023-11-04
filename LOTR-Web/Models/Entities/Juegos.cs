using System;
using System.Collections.Generic;

namespace LOTR_Web.Models.Entities;

public partial class Juegos
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaPublicacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Clasificacion { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int IdEstudio { get; set; }

    public virtual Estudio IdEstudioNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
