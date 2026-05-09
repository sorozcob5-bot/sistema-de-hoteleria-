<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hoteles.aspx.cs" Inherits="Hoteles" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Gestión de Hoteles</title>
    <link rel="stylesheet" href="../index.css">
    <style>
        .form-container { max-width: 600px; margin: 20px auto; background: white; padding: 20px; border-radius: 8px; box-shadow: 0 2px 5px rgba(0,0,0,0.2); }
        .input-field { width: 100%; padding: 10px; margin: 10px 0; border: 1px solid #ccc; border-radius: 4px; }
        .btn-save { background: #28a745; color: white; padding: 10px; border: none; width: 100%; border-radius: 4px; cursor: pointer; }
        .grid-view { margin-top: 20px; width: 100%; border-collapse: collapse; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Registrar Nuevo Hotel</h2>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="input-field" placeholder="Nombre del Hotel"></asp:TextBox>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="input-field" placeholder="Dirección"></asp:TextBox>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="input-field" placeholder="Teléfono"></asp:TextBox>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Hotel" CssClass="btn-save" OnClick="btnGuardar_Click" />
            <br /><br />
            <a href="MenuPrincipal.aspx">⬅ Volver al Menú</a>
            <hr />
            <asp:GridView ID="gvHoteles" runat="server" CssClass="grid-view"></asp:GridView>
        </div>
    </form>
</body>
</html>
