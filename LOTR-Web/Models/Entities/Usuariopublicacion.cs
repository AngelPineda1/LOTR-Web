using System;
using System.Collections.Generic;

namespace LOTR_Web.Models.Entities;

public partial class Usuariopublicacion
{
    public int IdPublicacion { get; set; }

    public int IdUsuario { get; set; }

    public virtual Publicaciones IdPublicacionNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
