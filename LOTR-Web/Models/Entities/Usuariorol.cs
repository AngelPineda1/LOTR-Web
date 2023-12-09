using System;
using System.Collections.Generic;

namespace LOTR_Web.Models.Entities;

public partial class Usuariorol
{
    public int IdUsuario { get; set; }

    public int IdRol { get; set; }

    public int Id { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
