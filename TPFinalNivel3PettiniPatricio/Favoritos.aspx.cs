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
                if (Request.QueryString["idArticulo"] != null)
                {
                    int idArticulo = Convert.ToInt32(Request.QueryString["idArticulo"]);
                    EliminarFavorito(idArticulo);
                }
                Validar();
                UsersEntity user = (UsersEntity)Session["user"];
                listaArticulosFavoritos = favoritosBusiness.GetFavoritosUser(user);
            }
            catch (Exception)
            {
                Session.Add("error", "ocurrio un error!");
                Response.Redirect("Error.aspx");
            }
        }

        void Validar()
        {
            EsAdmin = Validaciones.EsAdmin((UsersEntity)Session["user"]);
        }

        public void EliminarFavorito(int idArticulo)
        {
            UsersEntity user = (UsersEntity)Session["user"];
            favoritosBusiness.EliminarFavorito(user,idArticulo);
        }

        
    }
}