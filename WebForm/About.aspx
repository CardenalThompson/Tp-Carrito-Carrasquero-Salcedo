<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebForm.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg-light rounded-3 mt-3 p-3">
    <h1>Somos</h1>
    <h3>Edwin y Tomas, estudiantes de la carrera de programacion de la UTN.</h3>
    <p>Aprendemos a hacer una pagina web en ASP.net con C#</p>
    </div>

    <style>
        .git{
          font-size: 80px;
          margin-top: 0px;
          color:black;
          text-align: center;
        }
    </style>

    <div class="container-fluid text-center">
      <a class="btn btn-lg git" href="https://github.com/CardenalThompson/Tp-Carrito-Carrasquero-Salcedo"><i class="bi bi-github"></i></a>

    </div>

  
</asp:Content>
