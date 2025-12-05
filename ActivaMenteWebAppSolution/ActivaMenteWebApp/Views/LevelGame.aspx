<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LevelGame.aspx.cs" Inherits="ActivaMenteWebApp.Views.LevelGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="BtnLvl1" runat="server" Text="Nivel 1" OnClick="BtnLvl1_Click" />
            
            <asp:Button ID="BtnLvl2" runat="server" Text="Proximamente" Enabled="false"/>
            
            <asp:Button ID="BtnLvl3" runat="server" Text="Proximamente" Enabled="false"/>
    </form>
</body>
</html>
