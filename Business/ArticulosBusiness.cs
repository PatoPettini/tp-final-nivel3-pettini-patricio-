using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ArticulosBusiness
    {
        ArticulosDAL articulosDAL = new ArticulosDAL();

        public List<ArticulosEntity> GetArticulo()
        {
            return articulosDAL.Get();
        }

        public void ActualizarArticulo(ArticulosEntity art)
        {
            articulosDAL.Modificar(art);
        }
        public void AltaArticulo(ArticulosEntity art)
        {
            articulosDAL.Alta(art);
        }

        public void EliminarArticulo(ArticulosEntity art)
        {
            articulosDAL.Eliminar(art);
        }

        public ArticulosEntity GetUnArticulo(int id)
        {
            foreach (ArticulosEntity art in GetArticulo())
            {
                if (art.Id == id) return art;
            }
            return null;
        }

        public List<ArticulosEntity> listaFiltrada(string idCategoria, string idMarca, string PrecioMinimo, string PrecioMaximo)
        {//esta funcion lo que hace es filtrar por categoria, marca y precio.
            //En caso de que la categoria sea cualquiera se omite el filtro categoria y lo mismo para marca, o si los dos son cualquiera.
            List<ArticulosEntity> lista = new List<ArticulosEntity>();
            foreach (ArticulosEntity articulo in GetArticulo())
            {
                if (idCategoria == "Cualquiera" && idMarca == "Cualquiera") FiltrarPorPrecio(PrecioMinimo, PrecioMaximo, lista, articulo);
                else if (idCategoria == "Cualquiera" && idMarca != "Cualquiera")
                {
                    if (articulo.idMarca == Convert.ToInt32(idMarca))
                    {
                        FiltrarPorPrecio(PrecioMinimo, PrecioMaximo, lista, articulo);
                    }
                }
                else if (idCategoria != "Cualquiera" && idMarca == "Cualquiera")
                {
                    if (articulo.idCategoria == Convert.ToInt32(idCategoria))
                    {
                        FiltrarPorPrecio(PrecioMinimo, PrecioMaximo, lista, articulo);
                    }
                }
                else if (idCategoria != "Cualquiera" && idMarca != "Cualquiera")
                {
                    if (articulo.idCategoria == Convert.ToInt32(idCategoria) && articulo.idMarca == Convert.ToInt32(idMarca))
                    {
                        FiltrarPorPrecio(PrecioMinimo, PrecioMaximo, lista, articulo);
                    }
                }
            }
            return lista;
        }

        private static void FiltrarPorPrecio(string PrecioMinimo, string PrecioMaximo, List<ArticulosEntity> lista, ArticulosEntity articulo)
        {
            if (PrecioMinimo == "" && PrecioMaximo != "" && articulo.Precio <= Convert.ToDecimal(PrecioMaximo)) lista.Add(articulo);
            else if (PrecioMinimo != "" && PrecioMaximo == "" && articulo.Precio >= Convert.ToDecimal(PrecioMinimo)) lista.Add(articulo);//aca lo que hago es filtrar por precio, si escribio solo precio maximo, o solo minimo, los dos o ninguno. En cualquier caso se filtra la busqueda
            else if (PrecioMinimo != "" && PrecioMaximo != "" && articulo.Precio >= Convert.ToDecimal(PrecioMinimo) && articulo.Precio <= Convert.ToDecimal(PrecioMaximo)) lista.Add(articulo);
            else if (PrecioMinimo == "" && PrecioMaximo == "") lista.Add(articulo);
        }
    }
}
