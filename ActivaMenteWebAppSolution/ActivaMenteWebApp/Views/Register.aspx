<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ActivaMenteWebApp.Views.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Registro</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet">

    <style>
        body {
            background-color: #f0f4f8;
        }

        .card {
            background-color: #ffffff;
            border-radius: 10px;
            width: 24rem;
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
            <h2 class="text-center mb-4">Crear Cuenta</h2>

            <div class="mb-3">
                <label for="TxtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" placeholder="Tu nombre"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TxtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="TxtApellido" runat="server" CssClass="form-control" placeholder="Tu apellido"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Sexo</label>
                <asp:DropDownList ID="DdlSexo" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Seleccionar..." Value=""></asp:ListItem>
                    <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
                    <asp:ListItem Text="Femenino" Value="Femenino"></asp:ListItem>
                    <asp:ListItem Text="Otro" Value="Otro"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="TxtNacionalidad" class="form-label">Nacionalidad</label>
                <asp:TextBox ID="TxtNacionalidad" runat="server" CssClass="form-control" placeholder="Ej: Argentina"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TxtFechaNacimiento" class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox ID="TxtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TxtEmail" class="form-label">Correo Electrónico</label>
                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" placeholder="Ingresa tu email"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TxtUsuario" class="form-label">Nombre de Usuario</label>
                <asp:TextBox ID="TxtUsuario" runat="server" CssClass="form-control" placeholder="Tu nombre de usuario"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TxtPass" class="form-label">Contraseña</label>
                <asp:TextBox ID="TxtPass" runat="server" CssClass="form-control" TextMode="Password"
                    placeholder="Ingresa una contraseña"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TxtPass2" class="form-label">Confirmar Contraseña</label>
                <asp:TextBox ID="TxtPass2" runat="server" CssClass="form-control" TextMode="Password"
                    placeholder="Repite la contraseña"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TxtAvatar" class="form-label">Avatar (opcional)</label>
                <asp:TextBox ID="TxtAvatar" runat="server" CssClass="form-control" placeholder="URL de imagen"></asp:TextBox>
            </div>

            <asp:Button ID="BtnRegistrarse" runat="server" Text="Crear Cuenta"
                CssClass="btn btn-primary w-100 mb-3" OnClick="BtnRegistrarse_Click" />

            <asp:Literal ID="LitVolver" runat="server"
                Text="¿Ya tenés cuenta? <a href='LogIn.aspx' class='resaltar'>Iniciar Sesión</a>"></asp:Literal>

            <asp:Label ID="LblMensaje" runat="server" CssClass="text-danger mt-2"></asp:Label>
        </div>
    </form>
</body>
</html>
