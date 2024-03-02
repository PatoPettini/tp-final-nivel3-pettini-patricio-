<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ArticulosConForeach.aspx.cs" Inherits="TPFinalNivel3PettiniPatricio.ArticulosConForeach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <% 
            foreach (var articulo in ListaArticulos)
            {
        %>

        <div class="col">
            <div class="card">
                <img src="<%:articulo.ImagenUrl  %>" class="card-img-top" alt="...">
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
                    <%} %>
                </div>
            </div>
        </div>
        <% } %>
        <a href="ArticulosABM.aspx" class="btn btn-primary">Agregar producto</a>
    </div>

</asp:Content>
