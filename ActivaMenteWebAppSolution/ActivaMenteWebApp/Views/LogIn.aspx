<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="ActivaMenteWebApp.Views.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ActivaMente||LogIn</title>
    <link href="Styles/LogInStyles.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <img src="Multi/title.png" />
        </header>
        <main>
            <div class="container">
                <div class="presentation">
                    <div class="img">
                         <img src="Multi/reacts.png" />
                    </div>
                   <p>Transformamos el aprendizaje en diversión</p>

                </div>
                <div class="card">
                    <div class="title">Iniciar sesión</div>

                    <label>Nombre de usuario</label>
                    <asp:TextBox ID="TxtUserName" runat="server" CssClass="input"></asp:TextBox>

                    <label>Contraseña</label>
                    <asp:TextBox ID="TxtPass" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>

                    <asp:Button ID="BtnLogIn" runat="server" Text="Iniciar Aventura!" CssClass="btn" OnClick="BtnLogIn_Click" />
                    <asp:LinkButton ID="LkbSignUp" runat="server">Registrate GRATIS!</asp:LinkButton>

                    <asp:Label ID="LblWarning" runat="server" CssClass="warning"></asp:Label>
                </div>
            </div>
        </main>
        <footer>
            <h2>Activamente-Buenos Aires, Argentina.</h2>
        </footer>
    </form>
</body>
</html>
