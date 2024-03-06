<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPFinalNivel3PettiniPatricio.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server" />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="row row-cols-1 row-cols-md-3 g-4">

                <%foreach (Entity.ArticulosEntity articuloFav in listaArticulosFavoritos)
                    { %>

                <div class="col">
                    <div class="card">
                        <img src="<%:articuloFav.ImagenUrl  %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: articuloFav.Nombre %></h5>
                            <p class="card-text"><%: articuloFav.Marca.Descripcion %></p>
                            <p class="card-text"><%: articuloFav.Precio %></p>
                            <%if (!EsAdmin)
                                {%>
                            <a href="ArticulosABM.aspx?id=<%: articuloFav.Id %>">Ver</a>
                            <%} %>
                            <%if (EsAdmin)
                                {%>
                            <a class="btn btn-primary" href="ArticulosABM.aspx?id=<%:articuloFav.Id%>">Accion</a>
                            <%} %>
                            <a href="Favoritos.aspx?idArticulo=<%:articuloFav.Id %>" class="btn btn-danger">Eliminar Favorito</a>
                        </div>
                    </div>
                </div>
                <%} %>
            </div>
            <a href="ArticulosABM.aspx" class="btn btn-primary">Agregar Favoritos</a>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
