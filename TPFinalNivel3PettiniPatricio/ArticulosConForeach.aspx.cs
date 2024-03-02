using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3PettiniPatricio
{
    public partial class ArticulosConForeach : System.Web.UI.Page
    {
        ArticulosBusiness articulosBusiness = new ArticulosBusiness();
        public List<ArticulosEntity> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaArticulos=articulosBusiness.GetArticulo();
        }
    }
}