<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ranking.aspx.cs" Inherits="ActivaMenteWebApp.Views.Ranking" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ranking Global</title>
    <link href="Styles/RankingStyles.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">

        <h1>Ranking Global</h1>

        <asp:GridView 
            ID="gvRanking" 
            runat="server" 
            AutoGenerateColumns="false" 
            BorderColor="#000" 
            BorderStyle="Solid" 
            BorderWidth="1">
            <Columns>

                <asp:BoundField DataField="IdUsuario" HeaderText="ID Usuario" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                <asp:BoundField DataField="PuntosTotales" HeaderText="Puntaje Total" />

            </Columns>
        </asp:GridView>
        <asp:Button ID="BtnBack" runat="server" Text="Volver" OnClick="BtnBack_Click" CssClass="btn" />

    </form>
</body>
</html>
