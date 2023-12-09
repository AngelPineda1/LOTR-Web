using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LOTR_Web.Models.Entities;

public partial class LotrdbContext : DbContext
{
    public LotrdbContext()
    {
    }

    public LotrdbContext(DbContextOptions<LotrdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autor { get; set; }

    public virtual DbSet<Estudio> Estudio { get; set; }

    public virtual DbSet<Juegos> Juegos { get; set; }

    public virtual DbSet<Libros> Libros { get; set; }

    public virtual DbSet<Peliculas> Peliculas { get; set; }

    public virtual DbSet<Publicaciones> Publicaciones { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Usuarioinfo> Usuarioinfo { get; set; }

    public virtual DbSet<Usuariopublicacion> Usuariopublicacion { get; set; }

    public virtual DbSet<Usuariorol> Usuariorol { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("autor")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdUsuario, "fkPublicAutorUser_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Biografia).HasColumnType("text");
            entity.Property(e => e.FechaMuerte).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.IdUsuario).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(120);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Autor)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkPublicAutorUser");
        });

        modelBuilder.Entity<Estudio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("estudio")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdUsuario, "fkEstudioPublic_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.IdUsuario).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(120);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Estudio)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkEstudioUserPublic");
        });

        modelBuilder.Entity<Juegos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("juegos")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdEstudio, "fkJuegoEstudio_idx");

            entity.HasIndex(e => e.IdUsuario, "fkJuegoUsuarioPublic_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Clasificacion).HasMaxLength(4);
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            entity.Property(e => e.IdEstudio).HasColumnType("int(11)");
            entity.Property(e => e.IdUsuario).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(120);

            entity.HasOne(d => d.IdEstudioNavigation).WithMany(p => p.Juegos)
                .HasForeignKey(d => d.IdEstudio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkJuegoEstudio");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Juegos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkJuegoUsuarioPublic");
        });

        modelBuilder.Entity<Libros>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("libros")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdAutor, "fkPublicacionLibroIDAutor_idx");

            entity.HasIndex(e => e.IdUsuario, "fkPublicacionLibroUsuario_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Editorial).HasMaxLength(120);
            entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            entity.Property(e => e.IdAutor).HasColumnType("int(11)");
            entity.Property(e => e.IdUsuario).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(120);
            entity.Property(e => e.TiendaOficial).HasMaxLength(120);

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdAutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkPublicacionLibroIDAutor");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkPublicacionLibroUsuario");
        });

        modelBuilder.Entity<Peliculas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("peliculas")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdEstudio, "fkPublicacionEstudio_idx");

            entity.HasIndex(e => e.IdUsuario, "fkUsuarioPublicacionPelicula_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            entity.Property(e => e.IdEstudio).HasColumnType("int(11)");
            entity.Property(e => e.IdUsuario).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(120);

            entity.HasOne(d => d.IdEstudioNavigation).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.IdEstudio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkPublicacionEstudio");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkUsuarioPublicacionPelicula");
        });

        modelBuilder.Entity<Publicaciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("publicaciones")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Texto).HasColumnType("text");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("rol")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(80);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("usuario")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdInfo, "fkUsuarioInfo_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Contraseña).HasMaxLength(256);
            entity.Property(e => e.Correo).HasMaxLength(120);
            entity.Property(e => e.IdInfo).HasColumnType("int(11)");

            entity.HasOne(d => d.IdInfoNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdInfo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkUserInfoRel");
        });

        modelBuilder.Entity<Usuarioinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("usuarioinfo")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Nombre, "Nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Descripcion).HasColumnType("tinytext");
            entity.Property(e => e.Nombre).HasMaxLength(120);
        });

        modelBuilder.Entity<Usuariopublicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("usuariopublicacion")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdPublicacion, "fkPublicacionId_idx");

            entity.HasIndex(e => e.IdUsuario, "fkUsuarioPublicId_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdPublicacion).HasColumnType("int(11)");
            entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

            entity.HasOne(d => d.IdPublicacionNavigation).WithMany(p => p.Usuariopublicacion)
                .HasForeignKey(d => d.IdPublicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkPublicacionId");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Usuariopublicacion)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkUsuarioPublicId");
        });

        modelBuilder.Entity<Usuariorol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("usuariorol")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdRol, "fkRolId_idx");

            entity.HasIndex(e => e.IdUsuario, "fkUsuarioRolId_idx");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdRol).HasColumnType("int(11)");
            entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuariorol)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkRolId");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Usuariorol)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkUsuarioRolId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
