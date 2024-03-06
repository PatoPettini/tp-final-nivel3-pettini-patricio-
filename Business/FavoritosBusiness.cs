using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class FavoritosBusiness
    {
        FavoritosDAL favoritosDAL= new FavoritosDAL();
        ArticulosBusiness articulosBusiness= new ArticulosBusiness();
        public List<FavoritosEntity> GetFavoritos()
        {
            return favoritosDAL.Get();
        }

        public List<ArticulosEntity> GetFavoritosUser(UsersEntity user)
        {
            var aa = favoritosDAL.Get();
            List<int> lista= new List<int>();
            foreach(FavoritosEntity fav in GetFavoritos())
            {
                if (fav.idUser == user.Id) lista.Add(fav.idArticulo);//por cada favorito del usuario agregar a una lista el id de los articulos 
            }

            List<ArticulosEntity> listaArticulos= new List<ArticulosEntity>();
            foreach(int idArticulo in lista)
            {
                foreach(ArticulosEntity articulo in articulosBusiness.GetArticulo())
                {
                    if(idArticulo==articulo.Id) listaArticulos.Add(articulo);//cada articulo con el id de la lista anterior se agrega a una nueva
                                                                             //lista de articulos
                }
            }
            return listaArticulos;//se devuelve la lista de articulos
        }

        public void AltaFavorito(UsersEntity user, int idArticulo)
        {
            favoritosDAL.Alta(user, idArticulo);
        }
        
        public void EliminarFavorito(UsersEntity user, int idArticulo)
        {
            favoritosDAL.Eliminar(user, idArticulo);
        }
    }
}
