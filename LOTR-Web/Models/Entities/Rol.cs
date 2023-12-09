using System;
using System.Collections.Generic;

namespace LOTR_Web.Models.Entities;

public partial class Rol
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Usuariorol> Usuariorol { get; set; } = new List<Usuariorol>();
}
