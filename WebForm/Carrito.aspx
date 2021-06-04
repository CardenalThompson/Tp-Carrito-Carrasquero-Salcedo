<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebForm.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
    
      <table class="table table-hover">          
            <tr>
                <th scope="col"> </th>
                <th scope="col"> Codigo</th>
                <th scope="col">Nombre</th>
                <th scope="col">Precio</th> 
            </tr>                 
        
         <%foreach(Dominio.Articulo item in carritoCompra)
          { %>              
               <tr>
                   <td><img src="<%=item.imagen %>" alt="<%=item.imagen %>" width="100" height="100"></td>
                   <td> <b><%=item.codigo %> </b></td>
                   <td><%=item.nombre %></td>
                   <td><%=string.Format("{0:C}",item.precio) %></td>
                   <td><a class="btn btn-warning" href="Carrito.aspx?idCancelar=<%= item.id %>" role="button">Cancelar</a></td> 
       
              </tr>             
        <%}%>
     </table>

      <a href="Default.aspx" class ="btn btn-info btn lg" >Ver mas Articulos</a>
</asp:Content>
