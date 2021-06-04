<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">  
        <%
        foreach (Dominio.Articulo item in listaArticulos)
        { %>
            <div class="col-xs-12 col-sm-4 col-md-3" style="margin: 5px;">
                <div class="card text-center h-100 textodiv">
                    <div class="card-body d-flex flex-column">
                        <div class="col-md-4 col-sm-4 col-xs-4">
                        <img src="<%=item.imagen%>" style="max-height: 10vw; max-width: 10vw; margin: 3vw;" />
                            </div>
                        <div class="card-body">
                            <h4 class="card-title"> <b ><%= item.nombre %></b></h4>
                        <h5 class="card-title"><%= item.marca %></h5>
                        <h5 class="card-title"><%= string.Format("{0:C}", item.precio) %></h5>
                            </div>
                        
                        <a href="Carrito.aspx?idArticulo=<%=item.id.ToString() %>" class="btn btn-success"><i class="bi bi-cart4"></i> Agregar</a>
                        <br />
                        <a href="DetalleArticulo.aspx?idArticulo=<%=item.id.ToString() %>" class ="btn btn-info">Detalle</a>
                      
                         <%-- no debe tener espacios  el href si no te manda error de objeto no instanciado--%>
                    </div>
                </div>
             </div>
      <% } %>
   </div>
   
</asp:Content>
