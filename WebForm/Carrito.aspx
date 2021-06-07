<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebForm.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
    
     <div class="row pt-3">
        <div class="col-12 col-md-9  ">
             <table class="table table-hover">          
            <tr>
                <th scope="col"> </th>
                <th scope="col"> Codigo</th>
                <th scope="col">Nombre</th>
                <th scope="col">Precio</th> 
                <th scope="col">cantidad</th> 
            </tr>         
         <%foreach(Dominio.Articulo item in carritoCompra)
          { %>              
               <tr> 
                   <td><img src="<%=item.imagen %>" alt="No hay imagen" width="100" height="100"></td>
                   <td> <b><%=item.codigo %> </b></td>
                   <td><%=item.nombre %></td>
                   <td><%=string.Format("{0:C}",item.precio) %></td>
                   <td><a class="btn btn-primary" href="Carrito.aspx?idCant=<%= item.id %>" role="button">+</a></td> 
                   <td><a class="btn btn-warning" href="Carrito.aspx?idCancelar=<%= item.id %>" role="button">Cancelar</a></td> 
       
              </tr>             
        <%}%>
     </table>
        </div>
        <div class="col-12 col-md-3">
            <div class="total">
                <hr />
                <h3> El Precio total de tu compra es</h3>
                <hr />
                <asp:Label ID="lbtotal" runat="server" Text=""></asp:Label>

            </div>

        </div>      
    </div>
    <div class="container text-center mt-3">

           <a href="Default.aspx" class ="btn btn-success btn lg" >Ver mas Articulos</a>
    </div>
 
</asp:Content>
