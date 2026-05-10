<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Habitaciones.aspx.cs" Inherits="Habitaciones" Async="true" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8">
    <title>Gestión de Habitaciones</title>
    <link rel="stylesheet" href="../index.css">
    <style>
        .container { max-width: 850px; margin: 30px auto; background: white; padding: 30px; border-radius: 12px; box-shadow: 0 4px 15px rgba(0,0,0,0.1); font-family: sans-serif; }
        .form-row { display: flex; gap: 15px; margin-bottom: 15px; }
        .form-group { flex: 1; }
        .form-group label { display: block; font-weight: bold; margin-bottom: 5px; color: #003580; }
        .form-control { width: 100%; padding: 10px; border: 1px solid #ccc; border-radius: 6px; box-sizing: border-box; }
        .btn-add { background-color: #28a745; color: white; padding: 12px; border: none; border-radius: 6px; cursor: pointer; width: 100%; font-size: 1rem; margin-top: 10px; }
        .grid-view { margin-top: 30px; width: 100%; border-collapse: collapse; }
        .grid-view th { background-color: #003580; color: white; padding: 10px; }
    </style>
</head>
<body style="background-color: #f0f2f5;">
    <form id="form1" runat="server">
        <div class="container">
            <h2 style="color: #003580; text-align: center;">🛏️ Registro de Habitaciones</h2>
            
            <div class="form-group" style="margin-bottom: 15px;">
                <label>Seleccionar Hotel:</label>
                <asp:DropDownList ID="ddlHoteles" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>

            <div class="form-row">
                <div class="form-group">
                    <label>Número de Habitación:</label>
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" placeholder="Ej: 101"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Tipo:</label>
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Simple" Value="Simple"></asp:ListItem>
                        <asp:ListItem Text="Doble" Value="Doble"></asp:ListItem>
                        <asp:ListItem Text="Suite" Value="Suite"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <label>Precio por Noche (Q):</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="0.00"></asp:TextBox>
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="➕ Registrar Habitación" CssClass="btn-add" OnClick="btnGuardar_Click" />

            <br />
            <a href="MenuPrincipal.aspx" style="text-decoration:none; color:#003580;">⬅ Volver al Menú</a>

            <hr style="margin: 30px 0;">
            <asp:GridView ID="gvHabitaciones" runat="server" CssClass="grid-view" AutoGenerateColumns="true"></asp:GridView>
        </div>
    </form>
</body>
</html>
