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
        public bool EsAdmin { get; set; }
        ArticulosBusiness articulosBusiness = new ArticulosBusiness();
        CategoriasBusiness categoriasBusiness = new CategoriasBusiness();
        MarcasBusiness marcasBusiness = new MarcasBusiness();
        public FavoritosBusiness favoritosBusiness = new FavoritosBusiness();
        public List<ArticulosEntity> ListaArticulos { get; set; }
        public List<ArticulosEntity> ListaFiltrada { get; set; }
        public List<ArticulosEntity> listaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["user"] == null) Response.Redirect("Login.aspx");
                if (!IsPostBack)
                {
                    listaFavoritos = favoritosBusiness.GetFavoritosUser((UsersEntity)Session["user"]);
                    favoritos((UsersEntity)Session["user"]);
                    if (Request.QueryString["idArticulo"] != null)
                    {
                        int idArticulo = Convert.ToInt32(Request.QueryString["idArticulo"]);
                        AgregarFavorito(idArticulo);
                    }
                    if (Request.QueryString["idEliminarArticulo"] != null)
                    {
                        int idArticulo = Convert.ToInt32(Request.QueryString["idEliminarArticulo"]);
                        EliminarFavorito(idArticulo);
                    }
                    Session.Add("listaArticulos", articulosBusiness.GetArticulo());
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
                    Session.Add("listaArticulos", articulosBusiness.GetArticulo());
                    Validar();
                }
                ListaArticulos = (List<ArticulosEntity>)Session["listaArticulos"];
                if (chkFiltroAvanzado.Checked)
                {
                    txtArticulo.Enabled = false;
                    txtArticulo.Text = "";
                }
                else txtArticulo.Enabled = true;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx", false);
            }

        }

        public bool ValidarFavoritos(ArticulosEntity articulo)
        {
            UsersEntity user = (UsersEntity)Session["user"];
            var contador = 0;
            foreach (ArticulosEntity art in favoritosBusiness.GetFavoritosUser(user))
            {
                if (art.Id != articulo.Id) contador += 1;
            }
            if (contador == favoritosBusiness.GetFavoritosUser(user).Count()) return true;
            return false;
        }

        void Validar()
        {
            try
            {
                UsersEntity user = (UsersEntity)Session["user"];
                EsAdmin = Validaciones.EsAdmin(user);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }

        }
        void AgregarFavorito(int idArticulo)
        {
            try
            {
                UsersEntity user = (UsersEntity)Session["user"];
                favoritosBusiness.AltaFavorito(user, idArticulo);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }

        }
        public void favoritos(UsersEntity user)
        {
            try
            {
                listaFavoritos = favoritosBusiness.GetFavoritosUser(user);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }
        }
        public void EliminarFavorito(int idArticulo)
        {
            try
            {
                UsersEntity user = (UsersEntity)Session["user"];
                favoritosBusiness.EliminarFavorito(user, idArticulo);
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
                ListaFiltrada = lista.FindAll(a => a.Nombre.ToUpper().Contains(txtArticulo.Text.ToUpper()));
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
                ListaFiltrada = articulosBusiness.listaFiltrada(ddlCategoria.SelectedValue, ddlMarca.SelectedValue, txtPrecioDesde.Text, txtPrecioHasta.Text);
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
                ListaFiltrada = null;
                txtPrecioDesde.Text = "";
                txtPrecioHasta.Text = "";
                ddlCategoria.Text = "Cualquiera";
                ddlMarca.Text = "Cualquiera";
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }

        }
    }
}