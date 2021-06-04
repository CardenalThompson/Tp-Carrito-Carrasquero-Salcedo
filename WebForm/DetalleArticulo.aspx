<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="WebForm.DetalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Detalles</h1>
  <%--  <asp:Label Text="nombre" ID="lblseleccionado" runat="server"; />
    <asp:Image Text="imagen" ID="ImgUrlImagen" runat="server"; />
  --%>  
<div class="container">
  <div class="row">
    <div class="col-sm">
      <div class="col-md-15 col-sm-15 col-xs-15">
        <asp:Image ID="Imagenselecionado" class="img-fluid" runat="server" />
    </div>
    </div>
    <div class="col-sm">
        <h4><asp:Label ID="lblselecionado" runat="server" Text="Nombre"></asp:Label></h4>
        <div>
            <asp:Label ID="lblPrecio" runat="server" Text="Precio"></asp:Label>
        </div>
      <div>
        <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
      </div>
    </div>
  </div>
</div>
</asp:Content>