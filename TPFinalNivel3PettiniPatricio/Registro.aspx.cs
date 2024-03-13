using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3PettiniPatricio
{
    public partial class Registro : System.Web.UI.Page
    {
        UsersBusiness usersBusiness = new UsersBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            UsersEntity user = (UsersEntity)Session["user"];
            if (user != null)
            {
                txtEmail.Text = user.Email;
                txtPass.Text = user.Pass;
                txtApellido.Text = user.Apellido;
                txtNombre.Text= user.Nombre;
            }
        }

        protected void btnResgistrarme_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid) return;

                UsersEntity user = new UsersEntity
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    Pass = txtPass.Text,
                    admin = false
                };
                if (user.Email == "" || user.Pass == "" || user.Nombre=="" || user.Apellido=="")
                {
                    Session.Add("error", "Debes completar todos los campos");
                    Response.Redirect("error.aspx");
                }
                usersBusiness.AltaUser(user);
                Session.Add("user", user);
                ServicioEmail servicioEmail = new ServicioEmail();
                servicioEmail.ArmarCorreo(user.Email, "Registro", "<h1>Hola " + user.Nombre + "!</h1> <br>Tu registro fue exitoso, te damos la bienvenida a la comunidad.");
                servicioEmail.EnviarEmail();
                Response.Redirect("MiPerfil.aspx");
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