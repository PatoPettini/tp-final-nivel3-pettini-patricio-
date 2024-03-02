<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GrillaArticulosAdmin.aspx.cs" Inherits="TPFinalNivel3PettiniPatricio.GrillaArticulosAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:GridView ID="dgvArticulosAdmin" DataKeyNames="id" OnSelectedIndexChanged="dgvArticulosAdmin_SelectedIndexChanged" AutoGenerateColumns="false" CssClass="table table-dark table-bordered" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
        </Columns>
    </asp:GridView>
    <a href="ArticulosABM.aspx">Agregar Articulo</a>

</asp:Content>
