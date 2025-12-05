<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ActivaMenteWebApp.Views.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="LblUserName" runat="server" Text="user"></asp:Label>
        <asp:Button ID="BtnLogOut" runat="server" Text="Cerrar sesion" OnClick="BtnLogOut_Click" />
        <asp:Button ID="BtnProfile" runat="server" Text="Profile" OnClick="BtnProfile_Click" />
        <label>dashboard</label>
        <asp:Button ID="BtnRanking" runat="server" Text="Ranking" />
        <asp:Button ID="BtnGame1" runat="server" Text="Game 1" OnClick="BtnGame1_Click" />
        <asp:Button ID="BtnGame2" runat="server" Text="Proximamente mas niveles!" Enabled="false" />

    </form>
</body>
</html>
