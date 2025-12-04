<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="ActivaMenteWebApp.Views.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <label>Nombre de usuario</label>
        <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>
        <label>Contraseña</label>
        <asp:TextBox ID="TxtPass" runat="server"></asp:TextBox>
        <asp:Button ID="BtnLogIn" runat="server" Text="Confirmar" OnClick="BtnLogIn_Click" />
        <asp:Label ID="LblWarning" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
