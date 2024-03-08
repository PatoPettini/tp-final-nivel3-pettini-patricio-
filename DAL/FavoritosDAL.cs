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
    public class FavoritosDAL
    {
        public List<FavoritosEntity> Get()
        {
            using (Context context= new Context())
            {
                return context.FAVORITOS.ToList().Select(f=> new FavoritosEntity
                {
                    Id= f.Id,
                    idUser= f.IdUser,
                    idArticulo=f.IdArticulo
                }).ToList();
            }
        }
        public void Alta(UsersEntity user, int idArticulo)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Catalogo"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Insert into Favoritos (idUser, idArticulo) values (@idUser,@idArticulo)", connection))
                {
                    command.Parameters.AddWithValue("@idUser", user.Id);
                    command.Parameters.AddWithValue("@idArticulo", idArticulo);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(UsersEntity user,int idArticulo)
        {
            using (Context context = new Context())
            {
                FAVORITOS fAVORITOS = context.FAVORITOS.FirstOrDefault(f => f.IdUser == user.Id && f.IdArticulo==idArticulo);
                context.FAVORITOS.Remove(fAVORITOS);
                context.SaveChanges();
            }
        }
    }
}
