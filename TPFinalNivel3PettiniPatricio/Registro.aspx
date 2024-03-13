<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinalNivel3PettiniPatricio.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-3">
        <label for="txtEmail" class="form-label">Email</label>
        <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ErrorMessage="No tiene formato email" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtEmail" runat="server" />
    </div>
    <div class="mb-3">
        <label for="txtPass" class="form-label">Contraseña</label>
        <asp:TextBox ID="txtPass" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label for="txtNombre" class="form-label">Nombre</label>
        <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ErrorMessage="Solo letras!" ValidationExpression="^[A-ZÑa-zñáéíóúÁÉÍÓÚ'° ]+$" ControlToValidate="txtNombre" runat="server" />
    </div>
    <div class="mb-3">
        <label for="txtApellido" class="form-label">Apellido</label>
        <asp:TextBox ID="txtApellido" class="form-control" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ErrorMessage="Solo letras!" ValidationExpression="^[A-ZÑa-zñáéíóúÁÉÍÓÚ'° ]+$" ControlToValidate="txtApellido" runat="server" />
    </div>
    <asp:Button ID="btnResgistrarme" runat="server" Text="Resgistrarme" OnClick="btnResgistrarme_Click" CssClass="btn btn-primary" />
    <a href="Inicio.aspx">Cancelar</a>
</asp:Content>
