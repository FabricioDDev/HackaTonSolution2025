<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Game1.aspx.cs" Inherits="ActivaMenteWebApp.Views.Game1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblPregunta" runat="server" Text=""></asp:Label>

            <br /><br />

            <asp:RadioButtonList ID="rdbOpciones" runat="server"></asp:RadioButtonList>

            <br />

            <asp:Button ID="btnResponder" runat="server" Text="Responder" OnClick="btnResponder_Click" />

        </div>
    </form>
</body>
</html>
