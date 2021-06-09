<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
  <%-- ************* carrusel ******************--%>

     <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
       <div class="carousel-inner">
         <div class="carousel-item active" data-bs-interval="3000">
           <img src="img/motoBanner.jpg" class="d-block w-100" alt="...">
         </div>

         <div class="carousel-item" data-bs-interval="3000">
           <img src="img/SonyBanner.jpg" class="d-block w-100" alt="...">
         </div>

         <div class="carousel-item" data-bs-interval="3000">
           <img src="img/GalaxyBanner.jpg" class="d-block w-100" alt="...">
         </div>
       </div>

       <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
         <span class="carousel-control-prev-icon" aria-hidden="true"></span>
         <span class="visually-hidden">Previous</span>
       </button>
       <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
         <span class="carousel-control-next-icon" aria-hidden="true"></span>
         <span class="visually-hidden">Next</span>
       </button>
     </div>

       <br />
    <% if (listaArticulos.Count == 0)          //si no hay ningun articulo que coincida con la busuqeda
            {%>
              <br />
             <div class="container px-4">
                 <div class="row gx-5">
                   <div class="col12 col-sm-6">
                    <div class="p-3 border bg-light">
                        <img src="Img/sorry.jpg" class="card-img-top" alt="...">
                    </div>
                   </div>
                   <div class="col12 col-sm-6 text-center">
                     <div class="p-3 border bg-light ">
                          <h1 style="color:brown">Al parecer no hay articulos que coincidan con tu busqueda</h1>
                     </div>
                           <br />
                          <a href="Default.aspx" class ="btn btn-success btn lg" >Ver mas Articulos</a>
                   </div>
                 </div>
             </div>
                   
            
                
            <%}%>

    <div class="row pl-3">  
        <%
        foreach (Dominio.Articulo item in listaArticulos)
        { %>
                <div class="col-12 col-sm-6 col-md-4 col-lg-3 mb-3">
                   <div class="card text-center h-100 cardstyle">
                       <img src="<%=item.imagen%>" alt="no hay imagen"/>
                       <div class="card-body flex-column">
                               <h3 class="card-title"> <b ><%= item.nombre %>  </b><span class="badge bg-secondary">New</span></h3>
                               <h5 class="card-title"><%= item.marca %></h5>
                               <h5 class="card-title"><%= string.Format("{0:C}", item.precio) %></h5>
                       </div>
                       <div class="d-grid gap-2 col-9 mx-auto">
                          <a href="Carrito.aspx?idArticulo=<%=item.id.ToString() %>" class="btn btn-success"><i class="bi bi-cart4"></i> Agregar</a>
                          <br />
                          <a href="DetalleArticulo.aspx?idArticulo=<%=item.id.ToString() %>" class ="btn btn-info">Detalle</a>
                          <%--no debe tener espacios  el href si no te manda error de objeto no instanciado--%>
                      </div>
                  </div>    
                </div>
      <% } %>
     </div>
        
        <br />

      <div class="row bg-ligth">
          <div class="col col-12 col-sm-6 col-md-4  ">
               <div class="seguridad">
                     <p>
                        <i class="bi bi-truck"></i>
                    </p>
                    <h3>Envío gratis</h3>
                    <h6>Tenés envios gratis en miles de productos</h6>
               </div>
          </div>
          <div class="col col-12 col-sm-6 col-md-4 ">
               <div class="seguridad">
                     <p>
                        <i  class="bi bi-credit-card"></i>
                    </p>
                    <h3>Pagá con tarjeta o en efectivo</h3>
                    <h6>Tenés cuotas sin interés con tarjeta o efectivo en puntos de pago. ¡Y siempre es seguro!
                    </h6>
                </div>
          </div>
          <div class="col col-12  col-md-4  ">
              <div class="seguridad">
                     <p>
                        <i class="bi bi-shield-shaded"></i>
                    </p>
                    <h3>Seguridad, de principio a fin</h3>
                    <h6>No te gustá? Devolvelo sin problemas,siempre estas protegido</h6>
                </div>
          </div>
      </div>

    
</asp:Content>

