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
    public partial class GrillaArticulosAdmin : System.Web.UI.Page
    {
        ArticulosBusiness articulosBusiness= new ArticulosBusiness();
        CategoriasBusiness categoriasBusiness= new CategoriasBusiness();
        MarcasBusiness marcasBusiness = new MarcasBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Add("listaArticulos", articulosBusiness.GetArticulo());
                dgvArticulosAdmin.DataSource = Session["listaArticulos"];
                dgvArticulosAdmin.DataBind();
                ddlCategoria.DataSource = categoriasBusiness.GetCategorias();
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField ="id";
                ddlCategoria.DataBind();
                ddlMarca.DataSource = marcasBusiness.GetMarcas();
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField ="id";
                ddlMarca.DataBind();
            }
            if (chkFiltroAvanzado.Checked) txtArticulo.Enabled = false;
            else txtArticulo.Enabled = true;
        }

        protected void dgvArticulosAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvArticulosAdmin.SelectedDataKey.Value.ToString();
            Response.Redirect("ArticulosABM.aspx?id=" + id);
        }

        protected void txtArticulo_TextChanged(object sender, EventArgs e)
        {
            List<ArticulosEntity> lista = (List<ArticulosEntity>)Session["listaArticulos"];
            List<ArticulosEntity> listaFiltrada = lista.FindAll(a => a.Nombre.ToUpper().Contains(txtArticulo.Text.ToUpper()));
            dgvArticulosAdmin.DataSource = listaFiltrada;
            dgvArticulosAdmin.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            dgvArticulosAdmin.DataSource=articulosBusiness.listaFiltrada(ddlCategoria.SelectedValue, ddlMarca.SelectedValue);
            dgvArticulosAdmin.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvArticulosAdmin.DataSource = Session["listaArticulos"];
            dgvArticulosAdmin.DataBind();
        }
    }
}