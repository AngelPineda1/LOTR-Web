﻿using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;

namespace LOTR_Web.Repositories.Repositorios
{
    public class PublicacionesRepository :GenericRepository<Publicaciones>, IPublicacionesRepository
    {
        private readonly LotrdbContext _context;
        public PublicacionesRepository(LotrdbContext context) : base(context)
        {

            _context = context;

        }
        public Publicaciones GetPublicacionById(int Id)
        {
            Publicaciones Publicacion = base.GetById(Id);
            return Publicacion;
        }
    }
}