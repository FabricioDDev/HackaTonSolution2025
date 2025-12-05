<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ActivaMenteWebApp.Views.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DashBoard</title>
    <link href="Styles/DefaultStyle.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <!-- HEADER -->
        <header class="main-header">
            <div class="brand">
                <span>ActivaMente</span>
            </div>
            <div class="user-controls">
                <div class="user-info">
                    <span class="greeting">Hola,</span>
                    <span class="user-name"><asp:Label ID="LblUserName" runat="server" Text="user"></asp:Label></span>
                </div>
                <div class="action-buttons">
                    <asp:Button ID="BtnProfile" runat="server" Text="Tu Cuenta" CssClass="btn btn-outline" OnClick="BtnProfile_Click" />
                    <asp:Button ID="BtnLogOut" runat="server" Text="Cerrar sesión" CssClass="btn btn-danger" OnClick="BtnLogOut_Click" />
                </div>
            </div>
        </header>

        <!-- MAIN DASHBOARD -->
        <main class="dashboard-container">
            <div>
                <img src="Multi/happy.png" />
                <h1 class="page-title">Dashboard</h1>
            </div>
            
            <div class="dashboard-grid">
                <!-- Card de puntos -->
                <div class="card stats-card">
                    <div class="stats-info">
                        <label>Total de Puntos</label>
                        <span class="points-number"><asp:Label ID="LblTotalPoints" runat="server" Text=""></asp:Label></span>
                    </div>
                    <asp:Button ID="BtnRanking" runat="server" Text="Ranking" CssClass="btn btn-primary btn-block" OnClick="BtnRanking_Click" />
                </div>

                <!-- Card Juego 1 -->
                <div class="card game-card">
                    <div class="game-icon">🎮</div>
                    <h3>Game 1</h3>
                    <p>Diviértete y gana puntos!</p>
                    <asp:Button ID="BtnGame1" runat="server" Text="Jugar" CssClass="btn btn-success btn-block" OnClick="BtnGame1_Click" />
                </div>

                <!-- Card Juego 2 (deshabilitada) -->
                <div class="card game-card disabled-game">
                    <div class="game-icon">⏳</div>
                    <h3>Próximamente</h3>
                    <p>Más niveles disponibles pronto.</p>
                    <asp:Button ID="BtnGame2" runat="server" Text="Proximamente" CssClass="btn btn-disabled btn-block" Enabled="false" />
                </div>
            </div>
        </main>

        <!-- FOOTER -->
        <footer class="main-footer">
            <h2>ActivaMente - Buenos Aires, Argentina.</h2>
            <p>&copy; 2025 Todos los derechos reservados.</p>
        </footer>
    </form>
</body>
</html>
