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

        public void AgregarMarca(MarcasEntity marca)
        {
            marcasDAL.Alta(marca);
        }

        public MarcasEntity BuscarMarca(MarcasEntity marca)
        {
            foreach(MarcasEntity mar in GetMarcas())
            {
                if (marca.Descripcion == mar.Descripcion) return mar;
            }
            return null;
        }
    }
}
