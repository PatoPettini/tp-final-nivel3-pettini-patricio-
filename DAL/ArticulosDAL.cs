using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ArticulosDAL
    {
        public List<ArticulosEntity> Get()
        {
            using (Context context = new Context())
            {
                List<ArticulosEntity> lista= context.ARTICULOS.ToList().Select(a => new ArticulosEntity
                {
                    Id = a.Id,
                    Codigo = a.Codigo,
                    Descripcion = a.Descripcion,
                    Nombre = a.Nombre,
                    idMarca = Convert.ToInt32(a.IdMarca),
                    idCategoria = Convert.ToInt32(a.IdCategoria),
                    ImagenUrl = a.ImagenUrl,
                    Precio = Convert.ToDecimal(a.Precio)
                }).ToList();

                foreach(ArticulosEntity art in lista)
                {
                    CATEGORIAS cat= context.CATEGORIAS.FirstOrDefault(c=>c.Id== art.idCategoria);
                    art.Categoria = new CategoriasEntity();
                    art.Categoria.Descripcion= cat.Descripcion;
                    MARCAS marca = context.MARCAS.FirstOrDefault(m => m.Id == art.idMarca);
                    art.Marca=new MarcasEntity();
                    art.Marca.Descripcion=marca.Descripcion;
                }
                return lista;
            }
        }

        public void Alta(ArticulosEntity art)
        {
            ARTICULOS articulos = new ARTICULOS();
            articulos.Codigo = art.Codigo;
            articulos.Descripcion = art.Descripcion;
            articulos.Nombre = art.Nombre;
            articulos.IdMarca = art.idMarca;
            articulos.IdCategoria = art.idCategoria;
            articulos.ImagenUrl = art.ImagenUrl;
            articulos.Precio = art.Precio;
            using (Context context = new Context())
            {
                context.ARTICULOS.Add(articulos);
                context.SaveChanges();
            }
        }

        public void Modificar(ArticulosEntity art)
        {
            using (Context context = new Context())
            {
                ARTICULOS articulos = context.ARTICULOS.FirstOrDefault(u => u.Id == art.Id);
                articulos.Codigo = art.Codigo;
                articulos.Descripcion = art.Descripcion;
                articulos.Nombre = art.Nombre;
                articulos.IdMarca = art.idMarca;
                articulos.IdCategoria = art.idCategoria;
                articulos.ImagenUrl = art.ImagenUrl;
                articulos.Precio = art.Precio;
                context.SaveChanges();
            }
        }

        public void Eliminar(ArticulosEntity art)
        {
            using (Context context = new Context())
            {
                ARTICULOS articulos = context.ARTICULOS.FirstOrDefault(u => u.Id == art.Id);
                context.ARTICULOS.Remove(articulos);
                context.SaveChanges();
            }
        }
    }
}
