using System;
using System.Collections.Generic;

namespace LOTR_Web.Models.Entities;

public partial class Peliculas
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaPublicacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdEstudio { get; set; }

    public int IdUsuario { get; set; }

    public virtual Estudio IdEstudioNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
