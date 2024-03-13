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
        FavoritosBusiness favoritosBusiness = new FavoritosBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["idArticulo"] != null)
                {
                    int idArticulo = Convert.ToInt32(Request.QueryString["idArticulo"]);
                    AgregarFavorito(idArticulo);

                }
                Session.Add("listaArticulos", articulosBusiness.GetArticulo());
                repRepetidor.DataSource = Session["listaArticulos"];
                repRepetidor.DataBind();
                Validar();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }
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
    }
}