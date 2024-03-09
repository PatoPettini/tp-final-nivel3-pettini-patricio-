<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TPFinalNivel3PettiniPatricio.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-6">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Contraseña</label>
                <asp:TextBox ID="txtPass" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6">
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtImagen" class="form-label">Imagen de Perfil</label>
                <asp:TextBox ID="txtImagenTexto" runat="server"></asp:TextBox>
                <asp:CheckBox ID="chkAgregarImagen" AutoPostBack="true" OnCheckedChanged="chkAgregarImagen_CheckedChanged" CssClass="form-control" Text="Agregar Imagen desde mi pc" runat="server" />
                <%if (chkAgregarImagen.Checked)
                    {%>
                <input type="file" id="txtImagen" class="form-control" runat="server" />
                <%} %>
                <asp:Image ID="ImagenID" Width="30%" CssClass="img-fluid mb-3" ImageUrl="https://acortar.link/fHURIm" runat="server" />
            </div>
            <%if (Business.Validaciones.EsAdmin(Usuario))
                { %>
            <div class="mb-3">
                <label for="txtAdmin" class="form-label">Admin</label>
                <asp:TextBox ID="txtAdmin" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <%} %>
        </div>
        <div class="col-md-4">
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" />
        </div>
    </div>
</asp:Content>
