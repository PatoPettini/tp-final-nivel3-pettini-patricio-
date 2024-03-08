using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MarcasDAL
    {
        public List<MarcasEntity> Get()
        {
            using (Context context = new Context())
            {
                return context.MARCAS.ToList().Select(m => new MarcasEntity
                {
                    Id = m.Id,
                    Descripcion = m.Descripcion,
                }).ToList();
            }
        }

        public void Alta(MarcasEntity marca)
        {
            MARCAS mARCAS= new MARCAS();
            mARCAS.Descripcion= marca.Descripcion;
            using (Context context= new Context())
            {
                context.MARCAS.Add(mARCAS);
                context.SaveChanges();
            }
        }
    }
}
