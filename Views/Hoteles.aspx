<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hoteles.aspx.cs" Inherits="Hoteles" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8">
    <title>Gestión de Hoteles - Sistema Hotelero</title>
    <link rel="stylesheet" href="../index.css">
    <style>
        .container { max-width: 800px; margin: 30px auto; background: white; padding: 30px; border-radius: 12px; box-shadow: 0 4px 15px rgba(0,0,0,0.1); }
        .form-group { margin-bottom: 15px; }
        .form-group label { display: block; font-weight: bold; margin-bottom: 5px; color: #003580; }
        .form-control { width: 100%; padding: 10px; border: 1px solid #ccc; border-radius: 6px; box-sizing: border-box; }
        .btn-save { background-color: #28a745; color: white; padding: 12px 20px; border: none; border-radius: 6px; cursor: pointer; width: 100%; font-size: 1rem; }
        .btn-save:hover { background-color: #218838; }
        .grid-view { margin-top: 30px; width: 100%; border-collapse: collapse; }
        .grid-view th { background-color: #003580; color: white; padding: 10px; }
        .grid-view td { border: 1px solid #ddd; padding: 8px; }
        .back-link { display: inline-block; margin-top: 20px; text-decoration: none; color: #003580; font-weight: bold; }
    </style>
</head>
<body style="background-color: #f0f2f5;">
    <form id="form1" runat="server">
        <div class="container">
            <h2 style="color: #003580; text-align: center;">🏢 Registro de Hoteles</h2>
            
            <div class="form-group">
                <label>Nombre del Hotel:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ej: Hotel Gran Jaguar"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Dirección:</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Calle y Avenida..."></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Teléfono:</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="8888-8888"></asp:TextBox>
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="💾 Guardar Hotel" CssClass="btn-save" OnClick="btnGuardar_Click" />

            <a href="MenuPrincipal.aspx" class="back-link">⬅ Volver al Menú Principal</a>

            <hr style="margin: 30px 0; border: 0; border-top: 1px solid #eee;">

            <h3 style="color: #333;">Listado de Hoteles Activos</h3>
            <asp:GridView ID="gvHoteles" runat="server" CssClass="grid-view" AutoGenerateColumns="true">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
