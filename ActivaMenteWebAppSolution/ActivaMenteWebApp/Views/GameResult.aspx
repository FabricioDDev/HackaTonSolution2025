<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameResult.aspx.cs" Inherits="ActivaMenteWebApp.Views.GameResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div class="container">
            <h2>¡Juego completado!</h2>

            <asp:Label ID="lblMensaje" runat="server" CssClass="puntaje" />

            <asp:Button ID="btnVolver" runat="server" CssClass="btn" 
                Text="Volver a Juegos" OnClick="btnVolver_Click" />
        </div>
    </form>
</body>
</html>
