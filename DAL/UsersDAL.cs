using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            string conexion = ConfigurationManager.ConnectionStrings["Catalogo"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Insert into Users (email, pass, nombre, apellido) values (@email,@pass, @nombre, @apellido)", connection))
                {
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@pass", user.Pass);
                    command.Parameters.AddWithValue("@nombre", user.Nombre);
                    command.Parameters.AddWithValue("@apellido", user.Apellido);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Modificar(UsersEntity user)
        {
            using (Context context= new Context())
            {
                USERS usuario = context.USERS.FirstOrDefault(u => u.Id == user.Id);
                usuario.nombre = user.Nombre;
                usuario.apellido = user.Apellido;
                usuario.admin = user.admin;
                usuario.urlImagenPerfil = user.urlImagenPerfil;
                context.SaveChanges();
            }
        }
    }
}
