using System;
using System.Collections.Generic;

namespace LOTR_Web.Models.Entities;

public partial class Autor
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Biografia { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public DateTime FechaMuerte { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Libros> Libros { get; set; } = new List<Libros>();
}
