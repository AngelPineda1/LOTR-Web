using System;
using System.Collections.Generic;

namespace LOTR_Web.Models.Entities;

public partial class Usuarioinfo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
