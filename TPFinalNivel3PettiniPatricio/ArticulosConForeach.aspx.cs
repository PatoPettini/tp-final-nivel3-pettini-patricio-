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
        CategoriasBusiness categoriasBusiness= new CategoriasBusiness();
        MarcasBusiness marcasBusiness= new MarcasBusiness();
        FavoritosBusiness favoritosBusiness = new FavoritosBusiness();
        public List<ArticulosEntity> ListaArticulos { get; set; }
        public List<ArticulosEntity> ListaFiltrada { get; set; }
        public List<ArticulosEntity> listaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
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
                ddlMarca.DataSource = marcasBusiness.GetMarcas();
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "id";
                ddlMarca.DataBind();
                Session.Add("listaArticulos", articulosBusiness.GetArticulo());
                Validar();
            }
            ListaArticulos = (List<ArticulosEntity>)Session["listaArticulos"];
            if (chkFiltroAvanzado.Checked) txtArticulo.Enabled = false;
            else txtArticulo.Enabled = true;
        }

        void Validar()
        {
            UsersEntity user = (UsersEntity)Session["user"];
            EsAdmin = Validaciones.EsAdmin(user);
        }
        void AgregarFavorito(int idArticulo)
        {
            UsersEntity user = (UsersEntity)Session["user"];
            favoritosBusiness.AltaFavorito(user, idArticulo);
        }
        public void favoritos(UsersEntity user)
        {
            listaFavoritos = favoritosBusiness.GetFavoritosUser(user);
        }
        public void EliminarFavorito(int idArticulo)
        {
            UsersEntity user = (UsersEntity)Session["user"];
            favoritosBusiness.EliminarFavorito(user, idArticulo);
        }

        protected void txtArticulo_TextChanged(object sender, EventArgs e)
        {
            List<ArticulosEntity> lista = (List<ArticulosEntity>)Session["listaArticulos"];
            ListaFiltrada = lista.FindAll(a => a.Nombre.ToUpper().Contains(txtArticulo.Text.ToUpper()));
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            ListaFiltrada = articulosBusiness.listaFiltrada(ddlCategoria.SelectedValue, ddlMarca.SelectedValue);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ListaFiltrada=null;
        }
    }
}