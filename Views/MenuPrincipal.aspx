<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8">
    <title>Menú Principal - Sistema Hotelero</title>
    <link rel="stylesheet" href="../index.css">
    <style>
        .menu-container {
            max-width: 900px;
            margin: 50px auto;
            text-align: center;
            font-family: Arial, sans-serif;
        }
        .grid-menu {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
            gap: 20px;
            padding: 20px;
        }
        .card {
            background: white;
            padding: 30px;
            border-radius: 12px;
            box-shadow: 0 4px 10px rgba(0,0,0,0.1);
            text-decoration: none;
            color: #333;
            transition: transform 0.2s;
            border: none;
            cursor: pointer;
        }
        .card:hover { transform: translateY(-5px); background: #f0f7ff; }
        .icon { font-size: 40px; margin-bottom: 15px; display: block; }
        .btn-logout { background: #ff4d4d; color: white; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer; margin-top: 30px; }
    </style>
</head>
<body style="background-color: #f4f7f6;">
    <form id="form1" runat="server">
        <div class="menu-container">
            <h1>🏨 Sistema de Gestión Hotelera</h1>
            <p>Seleccione el módulo al que desea acceder:</p>

            <div class="grid-menu">
                <asp:LinkButton ID="btnHoteles" runat="server" CssClass="card" OnClick="btnIrHoteles_Click">
                    <span class="icon">🏢</span>
                    <strong>Gestión de Hoteles</strong>
                </asp:LinkButton>

                <asp:LinkButton ID="btnHabitaciones" runat="server" CssClass="card" OnClick="btnIrHabitaciones_Click">
                    <span class="icon">🛏️</span>
                    <strong>Habitaciones</strong>
                </asp:LinkButton>

                <asp:LinkButton ID="btnClientes" runat="server" CssClass="card" OnClick="btnIrClientes_Click">
                    <span class="icon">👥</span>
                    <strong>Clientes</strong>
                </asp:LinkButton>

                <asp:LinkButton ID="btnReservas" runat="server" CssClass="card" OnClick="btnIrReservaciones_Click">
                    <span class="icon">📅</span>
                    <strong>Reservaciones</strong>
                </asp:LinkButton>
            </div>

            <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesión" CssClass="btn-logout" OnClick="btnCerrarSesion_Click" />
        </div>
    </form>
</body>
</html>
