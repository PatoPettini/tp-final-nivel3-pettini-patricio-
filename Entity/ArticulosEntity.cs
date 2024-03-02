using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ArticulosEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int idMarca { get; set; }
        public MarcasEntity Marca { get; set; }
        public int idCategoria { get; set; }
        public CategoriasEntity Categoria { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }
    }
}
