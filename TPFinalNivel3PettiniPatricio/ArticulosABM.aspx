<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ArticulosABM.aspx.cs" Inherits="TPFinalNivel3PettiniPatricio.ABMArticulos1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" ID="Manager1" />

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtImagen" class="form-label">Imagen</label>
                <asp:TextBox ID="txtImagen" OnTextChanged="txtImagen_TextChanged" AutoPostBack="true" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Image ID="imagenID" ImageUrl="https://acortar.link/fHURIm" Width="70%" runat="server" />
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox ID="txtCodigo" MaxLength="3" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control"></asp:DropDownList>
                <%if (Business.Validaciones.EsAdmin((Entity.UsersEntity)Session["user"]))
                    { %>
                <asp:CheckBox ID="chkAgregarMarca" AutoPostBack="true" Text="Agregar Marca" runat="server" />
                <asp:TextBox ID="txtMarcaNueva" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Button ID="btnAgregarMarca" runat="server" OnClick="btnAgregarMarca_Click" CssClass="btn btn-primary" Text="Agregar" />
                <%} %>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
                <%if (Business.Validaciones.EsAdmin((Entity.UsersEntity)Session["user"]))
                    { %>
                <asp:CheckBox ID="chkAgregarCategoria" AutoPostBack="true" Text="Agregar Categoria" runat="server" />
                <asp:TextBox ID="txtNuevaCategoria" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Button ID="btnAgregarCategoria" runat="server" CssClass="btn btn-primary" OnClick="btnAgregarCategoria_Click" Text="Agregar Categoria" />
                <%} %>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ErrorMessage="Solo numeros!" ValidationExpression="^[0-9]+$"
                    ControlToValidate="txtPrecio" runat="server" />
            </div>
        </div>

        <div class="mb-3">
            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" OnClick="btnAgregar_Click" Text="Agregar" />
            <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar_Click" Text="Eliminar" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <%if (ConfirmarEliminacion)
                        {  %>
                    <asp:CheckBox ID="chkConfimar" Text="Confirmar Eliminacion" runat="server" />
                    <asp:Button ID="btnConfirmar" runat="server" CssClass="btn btn-danger" OnClick="btnConfirmar_Click" Text="Eliminar" />
                    <%} %>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>
