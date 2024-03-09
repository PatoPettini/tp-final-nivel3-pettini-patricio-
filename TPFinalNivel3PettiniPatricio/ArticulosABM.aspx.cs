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
                SetearDropDownList();
                if (Request.QueryString["id"] != null)
                {
                    btnAgregar.Text = "Modificar";
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    ArticulosEntity articulo = articulosBusiness.GetUnArticulo(id);
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion.ToString();
                    ddlCategoria.SelectedValue = articulo.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = articulo.Marca.Id.ToString();
                    txtPrecio.Text = articulo.Precio.ToString();
                    if (string.IsNullOrEmpty(articulo.ImagenUrl)) imagenID.ImageUrl = "https://acortar.link/fHURIm";
                    else if(articulo.ImagenUrl == "articulo-" + articulo.Codigo + articulo.Nombre + articulo.Descripcion + articulo.idMarca + articulo.idCategoria + Convert.ToInt32(articulo.Precio) + ".jpg") imagenID.ImageUrl = "~/Images/" + articulo.ImagenUrl;
                    else imagenID.ImageUrl=articulo.ImagenUrl;
                }
                UsersEntity user = (UsersEntity)Session["user"];
                if (!Validaciones.EsAdmin(user))
                {
                    NoEnableTextBox();
                }
            }
            ValidarCheckbox();
        }

        private void NoEnableTextBox()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtImagen.Enabled = false;
            txtPrecio.Enabled = false;
            ddlCategoria.Enabled = false;
            ddlMarca.Enabled = false;
            btnAgregar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void ValidarCheckbox()
        {
            if (chkAgregarMarca.Checked)
            {
                ddlMarca.Enabled = false; txtMarcaNueva.Visible = true; btnAgregarMarca.Visible = true;
            }
            else
            {
                ddlMarca.Enabled = true; txtMarcaNueva.Visible = false; btnAgregarMarca.Visible = false;
            }
            if (chkAgregarCategoria.Checked)
            {
                ddlCategoria.Enabled = false; txtNuevaCategoria.Visible = true; btnAgregarCategoria.Visible = true;
            }
            else
            {
                ddlCategoria.Enabled = true; txtNuevaCategoria.Visible = false; btnAgregarCategoria.Visible = false;
            }
        }

        private void SetearDropDownList()
        {
            ddlCategoria.DataSource = categoriasBusiness.GetCategorias();
            ddlCategoria.DataTextField = "descripcion";
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataBind();
            ddlMarca.DataSource = marcasBusiness.GetMarcas();
            ddlMarca.DataTextField = "descripcion";
            ddlMarca.DataValueField = "id";
            ddlMarca.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticulosEntity articulo = new ArticulosEntity
                {
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    idMarca = Convert.ToInt32(ddlMarca.SelectedValue),
                    idCategoria = Convert.ToInt32(ddlCategoria.SelectedValue),
                    Precio = Convert.ToDecimal(txtPrecio.Text)
                };
                if (Request.QueryString["id"] != null)
                {
                    articulo.Id = Convert.ToInt32(Request.QueryString["id"]);
                    ValidarMetodoDeImagen(articulo);
                    articulosBusiness.ActualizarArticulo(articulo);
                }
                else
                {
                    ValidarMetodoDeImagen(articulo);
                    articulosBusiness.AltaArticulo(articulo);
                };
                Response.Redirect("Inicio.aspx",false);
            }
            catch (Exception)
            {
                Response.Redirect("error.aspx");
            }
        }

        private void ValidarMetodoDeImagen(ArticulosEntity articulo)
        {
            if (!chkAgregarImagen.Checked) articulo.ImagenUrl = txtImagen.Text;
            else
            {
                if (ImagenArticulo.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    var foto = "articulo-" + articulo.Codigo + articulo.Nombre+ articulo.Descripcion+articulo.idMarca+articulo.idCategoria+Convert.ToInt32(articulo.Precio)+ ".jpg";
                    ImagenArticulo.PostedFile.SaveAs(ruta + foto);
                    articulo.ImagenUrl = foto;
                }
            }
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

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            if (txtMarcaNueva.Text != "")
            {
                MarcasEntity marca = new MarcasEntity();
                marca.Descripcion = txtMarcaNueva.Text;
                marcasBusiness.AgregarMarca(marca);
                txtMarcaNueva.Text = "";
                chkAgregarMarca.Checked = false;
                var dropSeleccionado = ddlCategoria.SelectedValue;
                SetearDropDownList();
                MarcasEntity mar = marcasBusiness.BuscarMarca(marca);
                ddlMarca.SelectedValue = mar.Id.ToString();
                chkAgregarMarca.Checked = false;
                ddlMarca.Enabled = true;
                txtMarcaNueva.Visible = false;
                btnAgregarMarca.Visible = false;
                ddlCategoria.SelectedValue = dropSeleccionado;
            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (txtNuevaCategoria.Text != "")
            {
                CategoriasEntity categoria = new CategoriasEntity();
                categoria.Descripcion = txtNuevaCategoria.Text;
                categoriasBusiness.AgregarCategoria(categoria);
                txtNuevaCategoria.Text = "";
                chkAgregarCategoria.Checked = false;
                var dropSeleccionado = ddlMarca.SelectedValue;
                SetearDropDownList();
                CategoriasEntity cat = categoriasBusiness.BuscarCategoria(categoria);
                ddlCategoria.SelectedValue = cat.Id.ToString();
                chkAgregarCategoria.Checked = false;
                ddlCategoria.Enabled = true;
                txtNuevaCategoria.Visible = false;
                btnAgregarCategoria.Visible = false;
                ddlMarca.SelectedValue = dropSeleccionado;
            }
        }

        protected void chkAgregarImagen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAgregarImagen.Checked)
            {
                txtImagen.Enabled = false; ImagenArticulo.Visible = true;
            }
            else
            {
                txtImagen.Enabled = true; ImagenArticulo.Visible = false;
            }
        }
    }
}