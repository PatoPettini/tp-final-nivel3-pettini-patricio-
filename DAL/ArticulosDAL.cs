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
                    art.Categoria.Id=cat.Id;
                    MARCAS marca = context.MARCAS.FirstOrDefault(m => m.Id == art.idMarca);
                    art.Marca=new MarcasEntity();
                    art.Marca.Descripcion=marca.Descripcion;
                    art.Marca.Id=marca.Id;
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

        public void Modificar(ArticulosEntity articulo)
        {
            string conexion = ConfigurationManager.ConnectionStrings["Catalogo"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("Update Articulos set Codigo = @Codigo, Nombre = @Nombre,Descripcion=@Descripcion,idMarca=@idMarca, idCategoria=@idCategoria, ImagenUrl=@ImagenUrl, Precio=@Precio where Id=@Id", connection))
                    {
                        command.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                        command.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", articulo.Descripcion);
                        command.Parameters.AddWithValue("@idMarca", articulo.idMarca);
                        command.Parameters.AddWithValue("@idCategoria", articulo.idCategoria);
                        if (!string.IsNullOrEmpty(articulo.ImagenUrl)) command.Parameters.AddWithValue("@ImagenUrl", articulo.ImagenUrl);
                        else command.Parameters.AddWithValue("@ImagenUrl", (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Precio", articulo.Precio);
                        command.Parameters.AddWithValue("@Id", articulo.Id);
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
