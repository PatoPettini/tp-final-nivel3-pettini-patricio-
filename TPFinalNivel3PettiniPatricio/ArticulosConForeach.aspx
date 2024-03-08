<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ArticulosConForeach.aspx.cs" Inherits="TPFinalNivel3PettiniPatricio.ArticulosConForeach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="SManager" />
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
                            <asp:Label ID="Label4" runat="server" Text="Precio Minimo"></asp:Label>
                            <asp:TextBox ID="txtPrecioDesde" runat="server"></asp:TextBox>
                            <asp:Label ID="Label5" runat="server" Text="Precio Maximo"></asp:Label>
                            <asp:TextBox ID="txtPrecioHasta" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" Text="Filtrar" />
                            <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" Text="Limpiar" />
                        </div>
                    </div>
                </div>
                <%}
                %>
            </div>
            <div class="row row-cols-1 row-cols-md-3 g-4">

                <%if (ListaFiltrada == null)
                    {
                        foreach (var articulo in ListaArticulos)
                        {
                %>

                <div class="col">
                    <div class="card">
                        <img src="<%:articulo.ImagenUrl%>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: articulo.Nombre %></h5>
                            <p class="card-text"><%: articulo.Marca.Descripcion %></p>
                            <p class="card-text"><%: articulo.Precio %></p>
                            <%if (!EsAdmin)
                                {%>
                            <a href="ArticulosABM.aspx?id=<%: articulo.Id %>">Ver</a>
                            <%} %>
                            <%if (EsAdmin)
                                {%>
                            <a class="btn btn-primary" href="ArticulosABM.aspx?id=<%:articulo.Id%>">Accion</a>
                            <%}%>
                            <a href="ArticulosConForeach.aspx?idArticulo=<%:articulo.Id%>" class="btn btn-secondary">Agregar a Favoritos</a>
                            <%-- lo que queria hacer aca es que si el articulo ya esta en favoritos que aparezca para eliminar de favoritos, en lugar de agregar otra vez --%>
                            <%--<%if (listaFavoritos.Count == 0)
                                {%>
                            <a href="ArticulosConForeach.aspx?idArticulo=<%:articulo.Id%>" class="btn btn-secondary">Agregar a Favoritos</a>
                            <%}%>
                            <%foreach (Entity.ArticulosEntity art in listaFavoritos)
                                {
                                    if (art.Id != articulo.Id)
                                    {
                            %>
                            <a href="ArticulosConForeach.aspx?idArticulo=<%:articulo.Id%>" class="btn btn-secondary">Agregar a Favoritos</a>
                            <%}
                                else
                                {
                            %>
                            <a href="ArticulosConForeach.aspx?idEliminarArticulo=<%:articulo.Id%>" class="btn btn-danger">Eliminar Favorito</a>
                            <%}
                                }
                            %>--%>
                        </div>
                    </div>
                </div>
                <% }
                    }
                    else
                    {
                        foreach (var articulo in ListaFiltrada)
                        {
                %>
                <div class="col">
                    <div class="card">
                        <img src="<%:articulo.ImagenUrl%>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: articulo.Nombre %></h5>
                            <p class="card-text"><%: articulo.Marca.Descripcion %></p>
                            <p class="card-text"><%: articulo.Precio %></p>
                            <%if (!EsAdmin)
                                {%>
                            <a href="ArticulosABM.aspx?id=<%: articulo.Id %>">Ver</a>
                            <%} %>
                            <%if (EsAdmin)
                                {%>
                            <a class="btn btn-primary" href="ArticulosABM.aspx?id=<%:articulo.Id%>">Accion</a>
                            <%}%>
                            <a href="ArticulosConForeach.aspx?idArticulo=<%:articulo.Id%>" class="btn btn-secondary">Agregar a Favoritos</a>
                        </div>
                    </div>
                </div>
                <%}
                    } %>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <a href="ArticulosABM.aspx" class="btn btn-primary">Agregar producto</a>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

