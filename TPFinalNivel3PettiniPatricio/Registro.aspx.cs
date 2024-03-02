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
    public partial class Registro : System.Web.UI.Page
    {
        UsersBusiness usersBusiness = new UsersBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResgistrarme_Click(object sender, EventArgs e)
        {
            UsersEntity user = new UsersEntity
            {
                Nombre = txtNombre.Text,
                Apellido=txtApellido.Text,
                Email=txtEmail.Text,
                Pass=txtPass.Text,
                admin=false
            };
            usersBusiness.AltaUser(user);
            Session.Add("user", user);
            Response.Redirect("inicio.aspx");
        }
    }
}