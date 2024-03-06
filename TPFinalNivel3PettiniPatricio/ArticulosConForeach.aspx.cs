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
        FavoritosBusiness favoritosBusiness = new FavoritosBusiness();
        public List<ArticulosEntity> ListaArticulos { get; set; }
        public bool IsPB { get; set; }
        public int Count { get; set; }
        public List<ArticulosEntity> listaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            listaFavoritos = favoritosBusiness.GetFavoritosUser((UsersEntity)Session["user"]);
            favoritos((UsersEntity)Session["user"]);
            if (Request.QueryString["idArticulo"] != null)
            {
                int idArticulo = Convert.ToInt32(Request.QueryString["idArticulo"]);
                IsPB= true;
                AgregarFavorito(idArticulo);
            }
            if (Request.QueryString["idEliminarArticulo"] != null)
            {
                int idArticulo = Convert.ToInt32(Request.QueryString["idEliminarArticulo"]);
                IsPB = true;
                EliminarFavorito(idArticulo);
            }
            Session.Add("listaArticulos", articulosBusiness.GetArticulo());
            ListaArticulos = (List<ArticulosEntity>)Session["listaArticulos"];
            Validar();
        }
        void Validar()
        {
            UsersEntity user= (UsersEntity)Session["user"];
            EsAdmin=Validaciones.EsAdmin(user);
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
    }
}