<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GrillaArticulosAdmin.aspx.cs" Inherits="TPFinalNivel3PettiniPatricio.GrillaArticulosAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" ID="ScriptManager" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label ID="Label2" runat="server" Text="Filtrar por articulo"></asp:Label>
                        <asp:TextBox runat="server" ID="txtArticulo" AutoPostBack="true" OnTextChanged="txtArticulo_TextChanged" CssClass="form-control" />
                        <asp:CheckBox Text="Filtro Avanzado" runat="server" ID="chkFiltroAvanzado" AutoPostBack="true" />
                    </div>
                </div>
                <%if (chkFiltroAvanzado.Checked)
                    { %>
                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label ID="Label1" runat="server" Text="Categoria"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCategoria">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label ID="Label3" runat="server" Text="Marca"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlMarca">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" Text="Filtrar" />
                            <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" Text="Limpiar" />
                        </div>
                    </div>
                </div>
                <%} %>

                <asp:GridView ID="dgvArticulosAdmin" DataKeyNames="id" OnSelectedIndexChanged="dgvArticulosAdmin_SelectedIndexChanged" AutoGenerateColumns="false" CssClass="table table-dark table-bordered" runat="server">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <a href="ArticulosABM.aspx">Agregar Articulo</a>

</asp:Content>
