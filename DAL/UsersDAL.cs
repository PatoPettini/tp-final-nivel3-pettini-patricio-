using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UsersDAL
    {
        public List<UsersEntity> Get()
        {
            using (Context context= new Context())
            {
                return context.USERS.ToList().Select(u => new UsersEntity
                {
                    Id=u.Id,
                    Email=u.email,
                    Nombre=u.nombre,
                    Apellido=u.apellido,
                    Pass=u.pass,
                    admin=u.admin,
                    urlImagenPerfil=u.urlImagenPerfil
                }).ToList();
            }
        }

        public void Alta(UsersEntity user)
        {
            USERS usuario = new USERS();
            usuario.nombre = user.Nombre;
            usuario.apellido = user.Apellido;
            usuario.email = user.Email;
            usuario.pass = user.Pass;
            usuario.admin = user.admin;
            usuario.urlImagenPerfil = user.urlImagenPerfil;
            using (Context context= new Context())
            {
                context.USERS.Add(usuario);
                context.SaveChanges();
            }
        }

        public void Modificar(UsersEntity user)
        {
            using (Context context= new Context())
            {
                USERS usuario = context.USERS.FirstOrDefault(u => u.Id == user.Id);
                usuario.nombre = user.Nombre;
                usuario.apellido = user.Apellido;
                usuario.email = user.Email;//puedo sacar las propiedades que no van a cambiar
                usuario.pass = user.Pass;
                usuario.admin = user.admin;
                usuario.urlImagenPerfil = user.urlImagenPerfil;
                context.SaveChanges();
            }
        }
    }
}
