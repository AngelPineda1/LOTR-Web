using System;
using System.Collections.Generic;

namespace LOTR_Web.Models.Entities;

public partial class Publicaciones
{
    public int Id { get; set; }

    public string Texto { get; set; } = null!;

    public DateTime Fecha { get; set; }
}
