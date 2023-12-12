using Humanizer;
using LOTR_Web.Areas.Admin.Models;
using LOTR_Web.Models.Entities;
using LOTR_Web.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace LOTR_Web.Repositories.Repositorios
{
    public class PublicacionesRepository : GenericRepository<Publicaciones>, IPublicacionesRepository
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
        public string GetUserName(int Id)
        {
            return _context.Usuario.Include(x => x.IdInfo).FirstOrDefault(x => x.Id == Id).IdInfoNavigation.Nombre;
        }
        public AdminPublicacionesViewModel GetPublicaciones()
        {
            Func<int?, bool> existeFoto = id =>
            {
                if (id.HasValue)
                {
                    string rutaImagen = $"wwwroot/publicaciones/{id.Value}.png";
                    return System.IO.File.Exists(rutaImagen);
                }
                else
                {
                    return false;
                }
            };

            AdminPublicacionesViewModel vm = new();
            vm.Publicaciones = _context.Usuariopublicacion.Include(x => x.IdPublicacionNavigation).Include(x => x.IdUsuarioNavigation).Include(x => x.IdUsuarioNavigation.IdInfoNavigation).OrderByDescending(x => x.Id).Select(x => new PublicacionesModel
            {
                Fecha = x.IdPublicacionNavigation.Fecha,
                Id = x.IdPublicacion,
                Texto = x.IdPublicacionNavigation.Texto,
                UserId = x.IdUsuario,
                UserName = x.IdUsuarioNavigation.IdInfoNavigation.Nombre,
                Archivo = existeFoto(x.IdPublicacion)
            });
            vm.AgregarPublicaciones = new();
            return vm;
        }

        public void InsertPublicacion(Publicaciones p, int Id)
        {
            base.Insert(p);
            
            Usuariopublicacion user = new()
            {
                IdPublicacion = p.Id,
                IdUsuario = Id
            };
            _context.Usuariopublicacion.Add(user);
            _context.SaveChanges();
        }
        public void UpdatePublicacion(Publicaciones p)
        {
            base.Update(p);
        }
        public void DeletePublicacion(Publicaciones p)
        {
            base.Delete(p);
        }
        

    }
}
