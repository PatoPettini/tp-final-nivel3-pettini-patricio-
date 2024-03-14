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
    public partial class MiPerfil : System.Web.UI.Page
    {
        public UsersEntity Usuario { get; set; }
        UsersBusiness usersBusiness = new UsersBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["user"] != null)
                    {
                        Usuario = (UsersEntity)Session["user"];
                        UsersEntity user = (UsersEntity)Session["user"];
                        txtEmail.Text = user.Email;
                        txtEmail.Enabled = false;
                        txtPass.Text = user.Pass;
                        txtPass.Enabled = false;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtAdmin.Text = user.admin.ToString();
                        txtAdmin.Enabled = false;
                        txtImagenTexto.Text = user.urlImagenPerfil;
                        ImagenID.ImageUrl = user.urlImagenPerfil;
                    }
                    else
                    {
                        Session.Add("error", "debe iniciar sesion para entrar aca!");
                        Response.Redirect("error.aspx");
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid) return;

                UsersEntity user = (UsersEntity)Session["user"];

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                if (txtImagenTexto.Text != "") user.urlImagenPerfil = txtImagenTexto.Text;
                usersBusiness.Actualizar(user);
                Session.Add("user", user);
                Response.Redirect("MiPerfil.aspx", false);

                Image imagenPerfil = (Image)Master.FindControl("imagePerfil");
                imagenPerfil.ImageUrl = "~/Images/" + user.urlImagenPerfil;
                ImagenID.ImageUrl = "~/Images/" + user.urlImagenPerfil;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }
        }
        public bool ValidarImagen()
        {

            UsersEntity user = (UsersEntity)Session["user"];
            if (!string.IsNullOrEmpty(user.urlImagenPerfil)) return true;
            return false;
        }

        protected void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                UsersEntity user = (UsersEntity)Session["user"];
                user.urlImagenPerfil = "";
                usersBusiness.Actualizar(user);
                Session.Add("user", user);
                Response.Redirect("MiPerfil.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }
        }
    }
}