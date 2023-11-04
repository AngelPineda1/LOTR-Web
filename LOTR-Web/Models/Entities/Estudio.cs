using System;
using System.Collections.Generic;

namespace LOTR_Web.Models.Entities;

public partial class Estudio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int IdUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Juegos> Juegos { get; set; } = new List<Juegos>();

    public virtual ICollection<Peliculas> Peliculas { get; set; } = new List<Peliculas>();
}
