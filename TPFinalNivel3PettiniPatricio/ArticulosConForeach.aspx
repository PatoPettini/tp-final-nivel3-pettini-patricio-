<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ArticulosConForeach.aspx.cs" Inherits="TPFinalNivel3PettiniPatricio.ArticulosConForeach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="SManager" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>



            <div class="row row-cols-1 row-cols-md-3 g-4">

                <% 
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
                %>
                <a href="ArticulosABM.aspx" class="btn btn-primary">Agregar producto</a>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
