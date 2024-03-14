using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3PettiniPatricio
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsersEntity user = (UsersEntity)Session["user"];
            ImagePerfil.ImageUrl = "https://acortar.link/otAY0i";

            if (user == null)
            {
                if (!(Page is LogIn || Page is Registro || Page is Error)) Response.Redirect("Login.aspx");
            }
            else
            {
                ImagePerfil.ImageUrl = "https://acortar.link/otAY0i";
                lblUser.Text = user.Nombre;
                if (!string.IsNullOrEmpty(user.urlImagenPerfil))
                {
                    ImagePerfil.ImageUrl = user.urlImagenPerfil;
                }
                if (Page is Registro || Page is LogIn)
                {
                    Session.Add("error", "Debe salir para loguearse o registrar una cuenta");
                    Response.Redirect("Error.aspx");
                }
            }
        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }
}