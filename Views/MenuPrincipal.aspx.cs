using System;

public partial class MenuPrincipal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) { }

    protected void btnIrHoteles_Click(object sender, EventArgs e) 
    { Response.Redirect("Hoteles.aspx"); }

    protected void btnIrHabitaciones_Click(object sender, EventArgs e) 
    { Response.Redirect("Habitaciones.aspx"); }

    protected void btnIrClientes_Click(object sender, EventArgs e) 
    { Response.Redirect("Clientes.aspx"); }

    protected void btnIrReservaciones_Click(object sender, EventArgs e) 
    { Response.Redirect("Reservaciones.aspx"); }

    protected void btnCerrarSesion_Click(object sender, EventArgs e) 
    { Response.Redirect("Login.aspx"); }
}
