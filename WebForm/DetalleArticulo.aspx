<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="WebForm.DetalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Articulo Seleccionado</h1>
  <%--  <asp:Label Text="nombre" ID="lblseleccionado" runat="server"; />
    <asp:Image Text="imagen" ID="ImgUrlImagen" runat="server"; />
  --%>  
    <h4><asp:Label ID="lblselecionado" runat="server" Text="Nombre"></asp:Label></h4>
    <asp:Image ID="Imagenselecionado" runat="server" />
    <asp:Label ID="lblPrecio" runat="server" Text="Precio"></asp:Label>
    <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
</asp:Content>
