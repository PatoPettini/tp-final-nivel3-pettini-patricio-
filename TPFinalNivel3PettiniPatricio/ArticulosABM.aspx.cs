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
    public partial class ABMArticulos1 : System.Web.UI.Page
    {
        CategoriasBusiness categoriasBusiness = new CategoriasBusiness();
        MarcasBusiness marcasBusiness = new MarcasBusiness();
        ArticulosBusiness articulosBusiness = new ArticulosBusiness();
        public bool ConfirmarEliminacion = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategoria.DataSource = categoriasBusiness.GetCategorias();
                ddlCategoria.DataTextField = "descripcion";
                ddlCategoria.DataValueField = "id";
                ddlCategoria.DataBind();
                ddlMarca.DataTextField = "descripcion";
                ddlMarca.DataValueField = "id";
                ddlMarca.DataSource = marcasBusiness.GetMarcas();
                ddlMarca.DataBind();

                if (Request.QueryString["id"] != null)
                {
                    btnAgregar.Text = "Modificar";
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    ArticulosEntity articulo = articulosBusiness.GetUnArticulo(id);
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    ddlCategoria.Text = articulo.Categoria.ToString();
                    ddlMarca.Text = articulo.Marca.ToString();
                    txtImagen.Text = articulo.ImagenUrl;
                    txtPrecio.Text = articulo.Precio.ToString();
                    imagenID.ImageUrl = txtImagen.Text;
                }
                UsersEntity user = (UsersEntity)Session["user"];
                if (!Validaciones.EsAdmin(user))
                {
                    txtCodigo.Enabled = false;
                    txtNombre.Enabled = false;
                    txtDescripcion.Enabled = false;
                    txtImagen.Enabled = false;
                    txtPrecio.Enabled = false;
                    ddlCategoria.Enabled = false;
                    ddlMarca.Enabled = false;
                    btnAgregar.Visible=false;
                    btnEliminar.Visible=false;
                }
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticulosEntity articulo = new ArticulosEntity
            {
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                idMarca = Convert.ToInt32(ddlMarca.SelectedValue),
                idCategoria = Convert.ToInt32(ddlCategoria.SelectedValue),
                ImagenUrl = txtImagen.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text)
            };
            if (Request.QueryString["id"] != null)
            {
                articulo.Id = Convert.ToInt32(Request.QueryString["id"]);
                articulosBusiness.ActualizarArticulo(articulo);
            }
            else articulosBusiness.AltaArticulo(articulo);

            Response.Redirect("Inicio.aspx");

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];
            ArticulosEntity articulo = new ArticulosEntity();
            articulo.Id = Convert.ToInt32(id);
            articulosBusiness.EliminarArticulo(articulo);
            Response.Redirect("Inicio.aspx");
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            imagenID.ImageUrl = txtImagen.Text;
        }
    }
}