<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ActivaMenteWebApp.Views.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles/ProfileStyle.css" rel="stylesheet" />
     <link rel="preconnect" href="https://fonts.googleapis.com">
     <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
     <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <header>
             <label>Cuenta</label>
             <asp:Button ID="BtnBack" runat="server" Text="volver" OnClick="BtnBack_Click" CssClass="back" />
        </header>
        <main>
             <div class="form">
                 <label>Nombre de Usuario</label>
                 <asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox>
                 <label>correo</label>
                 <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                 <label>Fecha de Registro</label>
                 <asp:TextBox ID="TxtRegisterDate" runat="server" TextMode="Date" Enabled="false"></asp:TextBox>
                 <label>Puntos Totales</label>
                 <asp:TextBox ID="TxtTotalPoints" runat="server" Enabled="false"></asp:TextBox>
                 <label>sexo</label>
                 <asp:DropDownList ID="DdlSex" runat="server"></asp:DropDownList>
                 <label>nacionalidad</label>
                 <asp:TextBox ID="TxtNationality" runat="server" Enabled="false"></asp:TextBox>
                 <label>fecha de nacimiento</label>
                 <asp:TextBox ID="TxtBornDate" runat="server" TextMode="Date"></asp:TextBox>
                 <asp:Button ID="BtnSave" runat="server" Text="Guardar cambios" OnClick="BtnSave_Click" CssClass="savebtn"/>
             </div>
             <asp:Label ID="LblWarning" runat="server" Text=""></asp:Label>
        </main>
        <footer>
            <h2>ActivaMente</h2>
        </footer>
    </form>
</body>
</html>
