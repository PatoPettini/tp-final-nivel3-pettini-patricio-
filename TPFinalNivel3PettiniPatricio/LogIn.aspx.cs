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
    public partial class LogIn : System.Web.UI.Page
    {
        UsersBusiness usersBusiness = new UsersBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            UsersEntity user = new UsersEntity()
            {
                Email=txtEmail.Text,
                Pass=txtPass.Text
            };
            UsersEntity usuario=usersBusiness.Validar(user);
            if (usuario != null) Session.Add("user", usuario); Response.Redirect("MiPerfil.aspx");
        }
    }
}