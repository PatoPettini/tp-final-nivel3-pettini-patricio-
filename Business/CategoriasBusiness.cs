using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace Business
{
    public class CategoriasBusiness
    {
        Class1 categoriasDAL = new Class1();

        public List<CategoriasEntity> GetCategorias()
        {
            return categoriasDAL.Get();
        }

        public void AgregarCategoria(CategoriasEntity categoria)
        {
            categoriasDAL.Alta(categoria);
        }
        public CategoriasEntity BuscarCategoria(CategoriasEntity categoria)
        {
            foreach (CategoriasEntity cat in GetCategorias())
            {
                if (categoria.Descripcion == cat.Descripcion) return cat;
            }
            return null;
        }

    }
}
