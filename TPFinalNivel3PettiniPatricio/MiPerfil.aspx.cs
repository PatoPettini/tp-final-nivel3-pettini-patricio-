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
                    else ImagenID.ImageUrl = "~/Images/" + user.urlImagenPerfil;
                }
                else
                {
                    Session.Add("error", "debe iniciar sesion para entrar aca!");
                    Response.Redirect("error.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            UsersEntity user = (UsersEntity)Session["user"];

            if (txtImagen.PostedFile.FileName != "")
            {
                string ruta = Server.MapPath("./Images/");
                var foto = "perfil-" + user.Id + ".jpg";
                txtImagen.PostedFile.SaveAs(ruta + foto);
                user.urlImagenPerfil = foto;
            }

            user.Nombre = txtNombre.Text;
            user.Apellido = txtApellido.Text;
            usersBusiness.Actualizar(user);
            Session.Add("user", user);
        }
    }
}