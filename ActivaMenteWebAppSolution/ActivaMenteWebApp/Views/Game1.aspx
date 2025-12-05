<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Game1.aspx.cs" Inherits="ActivaMenteWebApp.Views.Game1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ActivaMente - Juego</title>
    <link href="Styles/Game1Styles.css" rel="stylesheet" />
     <link rel="preconnect" href="https://fonts.googleapis.com">
     <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
     <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">
</head>

<body>
    <form id="form1" runat="server">
        <header>
             <span>ActivaMente</span>
             <asp:Label ID="LblQuestions" runat="server" Text=""></asp:Label>
        </header>
        <main>
             <asp:Panel ID="panelPregunta" runat="server" CssClass="card">
                 <asp:Label ID="lblPregunta" runat="server" Text=""></asp:Label>
                 <asp:RadioButtonList ID="rdbOpciones" runat="server"></asp:RadioButtonList>
                 <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
                 <asp:Button ID="btnResponder" runat="server" Text="Responder" CssClass="btn" OnClick="btnResponder_Click" />
             </asp:Panel>
             <asp:Panel ID="panelVideo" runat="server" CssClass="card-respuesta" Visible="false">
                  <video id="videoRespuesta" autoplay controls>
                      <source id="srcVideo" runat="server" type="video/mp4" />
                      Tu navegador no soporta video.
                  </video>
                  <asp:Label ID="LblCorrectaIncorrecta" runat="server" Text=""></asp:Label>
                  <asp:Label ID="LblRespuesta" runat="server" Text=""></asp:Label>
                  <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn" OnClick="btnAceptar_Click" />
              </asp:Panel>
        </main>
        <footer>
             <h2>ActivaMente - Buenos Aires, Argentina.</h2>
             <p>&copy; 2025 Todos los derechos reservados.</p>
        </footer>
    </form>
</body>
</html>
