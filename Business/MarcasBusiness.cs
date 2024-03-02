using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MarcasBusiness
    {
        MarcasDAL marcasDAL= new MarcasDAL();

        public List<MarcasEntity> GetMarcas()
        {
            return marcasDAL.Get();
        }
    }
}
