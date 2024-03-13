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
            string conexion = ConfigurationManager.ConnectionStrings["Catalogo"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("Update users set urlImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido Where Id = @id", connection))
                    {
                        if (!string.IsNullOrEmpty(user.urlImagenPerfil)) command.Parameters.AddWithValue("@imagen", user.urlImagenPerfil);
                        else command.Parameters.AddWithValue("@imagen", (object)DBNull.Value);
                        //command.Parameters.AddWithValue("@imagen", !string.IsNullOrEmpty(user.urlImagenPerfil) ? user.urlImagenPerfil : (object)DBNull.Value);
                        //command.Parameters.AddWithValue("@imagen", (object)user.imagenPerfil ?? DBNull.Value);
                        command.Parameters.AddWithValue("@nombre", user.Nombre);
                        command.Parameters.AddWithValue("@apellido", user.Apellido);
                        command.Parameters.AddWithValue("@id", user.Id);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}
