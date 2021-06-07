<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="WebForm.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header>

        <div class="row">
            <figure class="text-center">
                <h1>Articulos E & T</h1>
            </figure>
        </div>
    </header>

    <%foreach (Dominio.Articulo item in detalles)


        { %>
    <div class="container">
        <div class="row bg-gradient">
            <div class="col-sm">
                <div class="col-md-10 col-sm-10 col-xs-1">
                    <img src="<%=item.imagen%>" />
                </div>
            </div>
            <div class="card" style="width: 25rem">
                <figure class="text-center">
                    <h3>Detalle del artículo</h3>
                </figure>
                <div class="card-body">
                    <h2 class="card-title"><%= item.nombre %></h2>
                    <h3 class="card-subtitle mb-2 text-muted">
                        <div>
                            <%= item.marca %>
                        </div>
                        <%= string.Format("{0:C}", item.precio) %>
                    </h3>
                    <h4>
                        <%= item.categoria.nombre %>
                    </h4>
                    <p class="card-text">
                        <%= item.descripcion %>
                    </p>
                </div>

                <div class="card-body">
                    <a href="Carrito.aspx?idArticulo=<%=item.id.ToString() %>" class="btn btn-success"><i class="bi bi-cart4"></i>Agregar</a>
                    <%--<br />--%>
                    <a href="Default.aspx" class="btn btn-info btn-bg">Volver</a>
                </div>
            </div>
        </div>
    </div>

    <% } %>
</asp:Content>


    