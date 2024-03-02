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
    public partial class Inicio : System.Web.UI.Page
    {
        public bool EsAdmin { get; set; }
        ArticulosBusiness articulosBusiness = new ArticulosBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("listaArticulos", articulosBusiness.GetArticulo());
            repRepetidor.DataSource = Session["listaArticulos"];
            repRepetidor.DataBind();
            Validar();
        }
        void Validar()
        {
            UsersEntity user = (UsersEntity)Session["user"];
            EsAdmin = Validaciones.EsAdmin(user);
        }
    }
}