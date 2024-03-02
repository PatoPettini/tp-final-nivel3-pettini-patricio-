﻿using Entity;
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
    }
}