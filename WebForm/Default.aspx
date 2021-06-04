<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <div id="carouselExampleControlsNoTouching" class="carousel slide" data-bs-touch="false" data-bs-interval="false">
        <div class="carousel-inner">
          <div class="carousel-item active">
            <img src="https://img.global.news.samsung.com/co/wp-content/uploads/2019/02/Regional_Galaxy_Banner2_704x160.jpg" class="d-block w-100" alt="...">
          </div>
          <div class="carousel-item">
            <img src="https://www.motorola.com.ar/arquivos/HeaderEdge4.jpg" class="d-block w-100" alt="...">
          </div>
          <div class="carousel-item">
            <img src="https://takate.uy/wp-content/uploads/2020/07/samsung.jpg" class="d-block w-100" alt="...">
          </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControlsNoTouching" data-bs-slide="prev">
          <span class="carousel-control-prev-icon" aria-hidden="true"></span>
          <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControlsNoTouching" data-bs-slide="next">
          <span class="carousel-control-next-icon" aria-hidden="true"></span>
          <span class="visually-hidden">Next</span>
        </button>
    </div>



    <% if (listaArticulos.Count == 0)          //si no hay ningun articulo que coincida con la busuqeda
            {%>
              <br />
             <div class="container px-4">
                 <div class="row gx-5">
                   <div class="col">
                    <div class="p-3 border bg-light">
                        <img src="Img/sorry.jpg" class="card-img-top" alt="...">
                    </div>
                   </div>
                   <div class="col text-center">
                     <div class="p-3 border bg-light ">
                          <h1 style="color:darkslategray">Al parecer no hay articulos que coincidan con tu busqueda</h1>
                     </div>
                           <br />
                          <a href="Default.aspx" class ="btn btn-info btn lg" >Ver mas Articulos</a>
                   </div>
                 </div>
             </div>
                   
            
                
            <%}%>

    <div class="row">  
        <%
        foreach (Dominio.Articulo item in listaArticulos)
        { %>
            <div class="col-xs-12 col-sm-4 col-md-3" style="margin: 1vw;">
                <div class="card text-center h-100 textodiv">
                    <div class="card-body d-flex flex-column">
                        <div class="col-md-4 col-sm-4 col-xs-4">
                           <img src="<%=item.imagen%>" style="max-height: 10vw; max-width: 10vw; margin: 3vw;" />
                        </div>

                        <div class="card-body">
                            <h3 class="card-title"> <b ><%= item.nombre %></b></h3>
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
