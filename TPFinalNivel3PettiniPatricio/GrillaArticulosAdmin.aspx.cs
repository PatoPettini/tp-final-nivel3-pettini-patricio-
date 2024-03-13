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
        ArticulosBusiness articulosBusiness = new ArticulosBusiness();
        CategoriasBusiness categoriasBusiness = new CategoriasBusiness();
        MarcasBusiness marcasBusiness = new MarcasBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Validaciones.EsAdmin((UsersEntity)Session["user"]))
                {
                    Session.Add("error", "Se requieren permisos de admin para acceder a esta página");
                    Response.Redirect("error.aspx");
                }
                if (!IsPostBack)
                {
                    Session.Add("listaArticulos", articulosBusiness.GetArticulo());
                    dgvArticulosAdmin.DataSource = Session["listaArticulos"];
                    dgvArticulosAdmin.DataBind();
                    ddlCategoria.DataSource = categoriasBusiness.GetCategorias();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "id";
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Add("Cualquiera");
                    ddlMarca.DataSource = marcasBusiness.GetMarcas();
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "id";
                    ddlMarca.DataBind();
                    ddlMarca.Items.Add("Cualquiera");
                }
                if (chkFiltroAvanzado.Checked) txtArticulo.Enabled = false;
                else txtArticulo.Enabled = true;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }
        }

        protected void dgvArticulosAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvArticulosAdmin.SelectedDataKey.Value.ToString();
                Response.Redirect("ArticulosABM.aspx?id=" + id);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }

        }

        protected void txtArticulo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<ArticulosEntity> lista = (List<ArticulosEntity>)Session["listaArticulos"];
                List<ArticulosEntity> listaFiltrada = lista.FindAll(a => a.Nombre.ToUpper().Contains(txtArticulo.Text.ToUpper()));
                dgvArticulosAdmin.DataSource = listaFiltrada;
                dgvArticulosAdmin.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvArticulosAdmin.DataSource = articulosBusiness.listaFiltrada(ddlCategoria.SelectedValue, ddlMarca.SelectedValue,
                                txtPrecioDesde.Text, txtPrecioHasta.Text);
                dgvArticulosAdmin.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvArticulosAdmin.DataSource = Session["listaArticulos"];
                dgvArticulosAdmin.DataBind();
                txtPrecioDesde.Text = "";
                txtPrecioHasta.Text = "";
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }

        }
    }
}