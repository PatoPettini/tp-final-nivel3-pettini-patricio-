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
                        if (user.urlImagenPerfil == null) ImagenID.ImageUrl = "https://thumbs.dreamstime.com/b/perfil-de-usuario-vectorial-avatar-predeterminado-179376714.jpg";
                        else if (user.urlImagenPerfil == "user-" + user.Id + ".jpg") ImagenID.ImageUrl = "~/Images/" + user.urlImagenPerfil;
                        else ImagenID.ImageUrl = user.urlImagenPerfil;
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
                if (!string.IsNullOrEmpty(ValidarMetodoDeImagen(user)))
                {
                    user.urlImagenPerfil = ValidarMetodoDeImagen(user);
                }
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

        private string ValidarMetodoDeImagen(UsersEntity user)
        {
            if (!chkAgregarImagen.Checked) return txtImagenTexto.Text;
            else if (txtImagen.PostedFile.FileName != "")
            {
                string ruta = Server.MapPath("./Images/");
                var foto = "user-" + user.Id + ".jpg";
                txtImagen.PostedFile.SaveAs(ruta + foto);
                return foto;
            }
            return null;
        }

        public bool ValidarImagen()
        {

            UsersEntity user = (UsersEntity)Session["user"];
            if (!string.IsNullOrEmpty(user.urlImagenPerfil)) return true;
            return false;
        }

        protected void chkAgregarImagen_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAgregarImagen.Checked)
                {
                    txtImagenTexto.Enabled = false; txtImagen.Visible = true; txtImagenTexto.Text = "";
                }
                else
                {
                    txtImagenTexto.Enabled = true; txtImagen.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("error.aspx");
            }
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