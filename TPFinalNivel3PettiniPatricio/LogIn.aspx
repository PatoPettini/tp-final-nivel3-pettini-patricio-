<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TPFinalNivel3PettiniPatricio.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-3">
        <label for="txtEmail" class="form-label">Email</label>
        <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label for="txtPass" class="form-label">Contraseña</label>
        <asp:TextBox ID="txtPass" class="form-control" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="btnLogIn" OnClick="btnLogIn_Click" CssClass="btn btn-primary" runat="server" Text="Iniciar Sesion" />
    <a href="Inicio.aspx">Cancelar</a>
</asp:Content>
