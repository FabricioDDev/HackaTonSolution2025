<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Game1.aspx.cs" Inherits="ActivaMenteWebApp.Views.Game1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ActivaMente - Juego</title>

    <style>
        .card {
            border: 1px solid #ccc;
            padding: 20px;
            margin: 20px auto;
            width: 60%;
            border-radius: 12px;
            background: #fafafa;
            box-shadow: 0px 2px 8px rgba(0,0,0,0.15);
        }

        video {
            width: 100%;
            border-radius: 12px;
        }

        .btn {
            padding: 10px 20px;
            border-radius: 8px;
            border: none;
            cursor: pointer;
            background: #3498db;
            color: white;
            font-size: 16px;
        }

        .btn:hover {
            background: #2980b9;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <asp:Label ID="LblQuestions" runat="server" Text=""></asp:Label>
        <!-- TARJETA DE PREGUNTA -->
        <asp:Panel ID="panelPregunta" runat="server" CssClass="card">
            <asp:Label ID="lblPregunta" runat="server" Text=""></asp:Label>

            <br /><br />

            <asp:RadioButtonList ID="rdbOpciones" runat="server"></asp:RadioButtonList>

            <br />
            
            <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnResponder" runat="server" Text="Responder" CssClass="btn" OnClick="btnResponder_Click" />
        </asp:Panel>


        <!-- TARJETA DE VIDEO -->
        <asp:Panel ID="panelVideo" runat="server" CssClass="card" Visible="false">
            <video id="videoRespuesta" autoplay controls>
                <source id="srcVideo" runat="server" type="video/mp4" />
                Tu navegador no soporta video.
            </video>

            <br /><br />
            <asp:Label ID="LblCorrectaIncorrecta" runat="server" Text=""></asp:Label>

            <asp:Label ID="LblRespuesta" runat="server" Text=""></asp:Label>

            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn" OnClick="btnAceptar_Click" />
        </asp:Panel>

    </form>
</body>
</html>
