using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3PettiniPatricio
{
    public partial class GrillaArticulosAdmin : System.Web.UI.Page
    {
        ArticulosBusiness articulosBusiness= new ArticulosBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvArticulosAdmin.DataSource = articulosBusiness.GetArticulo();
                dgvArticulosAdmin.DataBind();
            }
        }

        protected void dgvArticulosAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvArticulosAdmin.SelectedDataKey.Value.ToString();
            Response.Redirect("ArticulosABM.aspx?id=" + id);
        }
    }
}