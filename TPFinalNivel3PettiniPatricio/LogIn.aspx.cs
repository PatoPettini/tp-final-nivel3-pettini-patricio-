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
            UsersEntity user = (UsersEntity)Session["user"];
            if (user != null)
            {
                txtEmail.Text = user.Email;
                txtPass.Text = user.Pass;
            }
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid) return;

                UsersEntity user = new UsersEntity()
                {
                    Email = txtEmail.Text,
                    Pass = txtPass.Text
                };
                if (user.Email == "" || user.Pass == "")
                {
                    Session.Add("error", "Debes completar ambos campos");
                    Response.Redirect("error.aspx");
                }
                UsersEntity usuario = usersBusiness.Validar(user);
                if (usuario != null) Session.Add("user", usuario); Response.Redirect("MiPerfil.aspx");
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }
        }
    }
}