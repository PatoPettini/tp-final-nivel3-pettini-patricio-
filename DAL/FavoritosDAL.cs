using DAL;
using Entity;
using System;
using System.Collections.Generic;
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
            FAVORITOS fAVORITOS= new FAVORITOS();
            fAVORITOS.IdArticulo=idArticulo;
            fAVORITOS.IdUser= user.Id;
            using (Context context= new Context())
            {
                context.FAVORITOS.Add(fAVORITOS);
                context.SaveChanges();
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
