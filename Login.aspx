<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Iniciar Sesión - Sistema de Hotelería</title>
    <link rel="stylesheet" href="index.css"> </head>
<body>
    <div class="login-container">
        <h2>Iniciar Sesión</h2>
        <form id="formLogin" runat="server">
            <div class="input-group">
                <label for="txtUsuario">Usuario:</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su usuario"></asp:TextBox>
            </div>
            
            <div class="input-group">
                <label for="txtPassword">Contraseña:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingrese su contraseña"></asp:TextBox>
            </div>

            <div class="button-group">
                <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn-primary" OnClick="btnLogin_Click" />
            </div>

            <div class="message-group">
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </form>
    </div>
</body>
</html>
