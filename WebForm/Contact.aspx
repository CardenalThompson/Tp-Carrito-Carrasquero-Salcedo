<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebForm.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <div class="col-6">
     <div class="mb-3">
       <label for="formGroupExampleInput" class="form-label">Nombre</label>
       <input type="text" class="form-control" id="formGroupExampleInput" placeholder="Nombre">
     </div>
     <div class="mb-3">
       <label for="formGroupExampleInput2" class="form-label">Correo electronico</label>
       <input type="text" class="form-control" id="formGroupExampleInput2" placeholder="Correo">
     </div>
     <div class="mb-3">
       <label for="formGroupExampleInput2" class="form-label">Comentarios</label>
       <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
     </div>
  </div>
         <div style="color:white;">
             <address>
                 Programacion 3 - UTN/FRGP<br />
                 Buenos Aires, Argentina<br />
             </address>
         </div>
       
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:edusalcedopaucar@gmail.com">edusalcedopaucar@gmail.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:tomas.carrasquero@outlook.com">tomas.carrasquero@outlook.com</a>
    </address>
</asp:Content>
