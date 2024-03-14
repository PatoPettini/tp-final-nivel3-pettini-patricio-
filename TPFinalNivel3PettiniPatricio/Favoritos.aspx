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
                        <% if (articuloFav.ImagenUrl == "articulo-" + articuloFav.Codigo + ".jpg" || string.IsNullOrEmpty
                                (articuloFav.ImagenUrl))
                            {%>
                        <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQmirI4PxLNSAAUf4tBZCiZjUtwrpt9oVu6NIshLIdqjNK9wWcjXgtWRr81WMbgJ7HuVlc&usqp=CAU" class="card-img-top" alt="...">
                        <%}
                            else
                            { %>
                        <img src="<%:articuloFav.ImagenUrl%>" class="card-img-top" alt="...">
                        <%} %>
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
            <div>
                <a href="ArticulosABM.aspx" class="btn btn-primary">Agregar Favoritos</a>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
