<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TPFinalNivel3PettiniPatricio.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function validar() {
            const txtNombre = document.getElementById("txtNombre");
            const txtApellido = document.getElementById("txtApellido");

            if (txtNombre.value == "" && txtApellido.value == "") {
                txtNombre.classList.add("is-invalid");
                txtNombre.classList.remove("is-valid");
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                return false;
            } else if (txtNombre.value != "" && txtApellido.value == "") {
                txtNombre.classList.add("is-valid");
                txtNombre.classList.remove("is-invalid");
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                return false;
            }
            else if (txtNombre.value == "" && txtApellido.value != "") {
                txtNombre.classList.add("is-invalid");
                txtNombre.classList.remove("is-valid");
                txtApellido.classList.add("is-valid");
                txtApellido.classList.remove("is-invalid");
                return false;
            } else {
                txtNombre.classList.add("is-valid");
                txtNombre.classList.remove("is-invalid");
                txtApellido.classList.add("is-valid");
                txtApellido.classList.remove("is-invalid");
            }
            return true;
        }
    </script>

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
                <asp:TextBox ID="txtNombre" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ErrorMessage="Solo letras!" ValidationExpression="^[A-ZÑa-zñáéíóúÁÉÍÓÚ'° ]+$" ControlToValidate="txtNombre" runat="server" />
            </div>
        </div>
        <div class="col-md-6">
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ErrorMessage="Solo letras!" ValidationExpression="^[A-ZÑa-zñáéíóúÁÉÍÓÚ'° ]+$" ControlToValidate="txtApellido" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtImagen" class="form-label">Imagen de Perfil</label>
                <asp:TextBox ID="txtImagenTexto" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Image ID="ImagenID" Width="30%" CssClass="img-fluid mb-3" ImageUrl="https://acortar.link/fHURIm" runat="server" />
            </div>
            <div class="mb-3">
                <%if (ValidarImagen())
                    { %>
                <asp:Button ID="btnEliminarImagen" runat="server" Text="Eliminar Imagen" CssClass="btn btn-danger" OnClick="btnEliminarImagen_Click" />
                <%} %>
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
            <asp:Button ID="btnGuardar" OnClientClick="return validar()" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" />
        </div>
    </div>
</asp:Content>
