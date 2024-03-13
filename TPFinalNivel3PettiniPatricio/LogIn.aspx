<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TPFinalNivel3PettiniPatricio.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 10px;
        }
    </style>
    <script>
        function validar() {
            const txtEmail = document.getElementById("txtEmail");
            const txtPass = document.getElementById("txtPass");

            if (txtEmail.value == "" && txtPass.value == "") {
                txtEmail.classList.add("is-invalid");
                txtEmail.classList.remove("is-valid");
                txtPass.classList.add("is-invalid");
                txtPass.classList.remove("is-valid");
                return false;
            } else if (txtEmail.value != "" && txtPass.value == "") {
                txtEmail.classList.add("is-valid");
                txtEmail.classList.remove("is-invalid");
                txtPass.classList.add("is-invalid");
                txtPass.classList.remove("is-valid");
                return false;
            }
            else if (txtEmail.value == "" && txtPass.value != "") {
                txtEmail.classList.add("is-invalid");
                txtEmail.classList.remove("is-valid");
                txtPass.classList.add("is-valid");
                txtPass.classList.remove("is-invalid");
                return false;
            } else {
                txtEmail.classList.add("is-valid");
                txtEmail.classList.remove("is-invalid");
                txtPass.classList.add("is-valid");
                txtPass.classList.remove("is-invalid");
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-6">
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" class="form-control" ClientIDMode="Static" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Debe completar el email" CssClass="validacion" ControlToValidate="txtEmail" runat="server" />
        </div>
        <asp:RegularExpressionValidator ErrorMessage="No tiene formato email" CssClass="validacion" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtEmail" runat="server" />
        <div class="mb-3">
            <label for="txtPass" class="form-label">Contraseña</label>
            <asp:TextBox ID="txtPass" ClientIDMode="Static" class="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="Debe completar la contraseña" CssClass="validacion" ControlToValidate="txtPass" runat="server" />
        </div>
        <asp:Button ID="btnLogIn" OnClientClick="return validar()" OnClick="btnLogIn_Click" CssClass="btn btn-primary" runat="server" Text="Iniciar Sesion" />
        <a href="Inicio.aspx">Cancelar</a>
    </div>
</asp:Content>
