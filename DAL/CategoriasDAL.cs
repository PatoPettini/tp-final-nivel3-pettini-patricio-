using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Class1
    {
        public List<CategoriasEntity> Get()
        {
            using (Context context= new Context())
            {
                return context.CATEGORIAS.ToList().Select(c => new CategoriasEntity
                {
                    Id = c.Id,
                    Descripcion = c.Descripcion
                }).ToList();
            }
        }
    }
}
