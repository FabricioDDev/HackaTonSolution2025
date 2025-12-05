<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LevelGame.aspx.cs" Inherits="ActivaMenteWebApp.Views.LevelGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles/LevelGameStyles.css" rel="stylesheet" />
     <link rel="preconnect" href="https://fonts.googleapis.com">
     <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
     <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <p>ActivaMente</p>
        </header>
        <main>
            <div>
                <h1>Niveles</h1>
                <div class="card stats-card">
                    <div class="stats-info">
                         <label>Nivel 1</label>
                        <img src="Multi/thinking.png" />
                    </div>
                    <asp:Button ID="BtnLvl1" runat="server" Text="Comenzar!" OnClick="BtnLvl1_Click" />
                </div>
                <div class="card stats-card">
                    <div class="stats-info">
                         <label>Nivel 2</label>
                    </div>
                     <asp:Button ID="BtnLvl2" runat="server" Text="Proximamente" Enabled="false"/>
                </div>
                <div class="card stats-card">
                    <div class="stats-info">
                         <label>Nivel 3</label>
                    </div>
                     <asp:Button ID="BtnLvl3" runat="server" Text="Proximamente" Enabled="false"/>
                </div>
             </div>
        </main>
        <footer>
            <h2>Activamente-Buenos Aires, Argentina.</h2>
        </footer>
           
    </form>
</body>
</html>
