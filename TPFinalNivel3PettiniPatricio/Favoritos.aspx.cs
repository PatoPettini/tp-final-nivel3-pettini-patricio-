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
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<ArticulosEntity> listaArticulosFavoritos { get; set; }
        FavoritosBusiness favoritosBusiness = new FavoritosBusiness();
        public bool EsAdmin { get; set; }
        public List<ArticulosEntity> listaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["user"] != null)
                {
                    if (Request.QueryString["idArticulo"] != null)
                    {
                        int idArticulo = Convert.ToInt32(Request.QueryString["idArticulo"]);
                        EliminarFavorito(idArticulo);
                    }
                    Validar();
                    UsersEntity user = (UsersEntity)Session["user"];
                    listaArticulosFavoritos = favoritosBusiness.GetFavoritosUser(user);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }

        void Validar()
        {
            try
            {
                EsAdmin = Validaciones.EsAdmin((UsersEntity)Session["user"]);
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


    }
}