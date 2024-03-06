<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPFinalNivel3PettiniPatricio.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <asp:Repeater ID="repRepetidor" runat="server">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card">
                                <img src="<%#Eval("ImagenUrl")  %>" class="card-img-top" alt="...">
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text"><%#Eval("Marca.Descripcion") %></p>
                                    <p class="card-text"><%#Eval("Precio") %></p>
                                    <a href="ArticulosABM.aspx?id=<%#Eval("Id") %>">Ver</a>
                                    <%if (EsAdmin)
                                        {%>
                                    <a class="btn btn-primary" href="ArticulosABM.aspx?id=<%#Eval("Id") %>">Accion</a>
                                    <%} %>
                                    <a href="Inicio.aspx?idArticulo=<%#Eval("Id")%>" class="btn btn-secondary">Agregar a Favoritos</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <a href="ArticulosABM.aspx" class="btn btn-primary">Agregar producto</a>


</asp:Content>
