using System;
using System.Collections.Generic;

namespace LOTR_Web.Models.Entities;

public partial class Libros
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Editorial { get; set; } = null!;

    public DateTime FechaPublicacion { get; set; }

    public string TiendaOficial { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int IdAutor { get; set; }

    public virtual Autor IdAutorNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
