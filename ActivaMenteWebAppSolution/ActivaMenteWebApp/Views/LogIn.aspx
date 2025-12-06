<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="ActivaMenteWebApp.Views.LogIn" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet">


    <style>
        body {
            background-color: #f0f4f8;
        }

        .card {
            background-color: #ffffff;
            border-radius: 10px;
            width: 22rem;
        }

        .btn-primary {
            background-color: #4CAF50;
            border: none;
        }

            .btn-primary:hover {
                background-color: #45a049;
            }

        .resaltar {
            color: red;
            font-weight: bold;
        }

            .resaltar:hover {
                text-decoration: underline;
            }
    </style>
</head>

<body>
    <form id="form1" runat="server" class="d-flex justify-content-center align-items-center min-vh-100">
        <div class="card p-4 shadow">
            <h2 class="text-center mb-4">Iniciar Sesión</h2>

            <div class="mb-3">
                <label for="TxtUserName" class="form-label">Correo Electrónico</label>
                <asp:TextBox ID="TxtUserName" runat="server" CssClass="form-control" placeholder="Ingresa tu correo"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TxtPass" class="form-label">Contraseña</label>
                <asp:TextBox ID="TxtPass" runat="server" CssClass="form-control" TextMode="Password"
                    placeholder="Ingresa tu contraseña"></asp:TextBox>
            </div>

            <asp:Button ID="BtnLogIn" runat="server" Text="Entrar"
                CssClass="btn btn-primary w-100" OnClick="BtnLogIn_Click" />

            <br />
            <asp:Literal ID="LitRegistration" runat="server"
                Text="No tenés cuenta? <a href='Register.aspx' class='resaltar'>Registrate</a>">
            </asp:Literal>

            <asp:Label ID="LblWarning" runat="server" Text="" CssClass="text-danger mt-2"></asp:Label>
        </div>
    </form>

</body>
</html>

