using System;
using System.Collections.Generic;

namespace LOTR_Web.Models.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int IdInfo { get; set; }

    public virtual ICollection<Autor> Autor { get; set; } = new List<Autor>();

    public virtual ICollection<Estudio> Estudio { get; set; } = new List<Estudio>();

    public virtual ICollection<Juegos> Juegos { get; set; } = new List<Juegos>();

    public virtual ICollection<Libros> Libros { get; set; } = new List<Libros>();

    public virtual ICollection<Peliculas> Peliculas { get; set; } = new List<Peliculas>();
}
