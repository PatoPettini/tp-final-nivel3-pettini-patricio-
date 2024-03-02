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
        
    }
}
