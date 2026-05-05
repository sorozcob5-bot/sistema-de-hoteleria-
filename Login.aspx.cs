using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;

public partial class Login : System.Web.UI.Page
{
    private readonly HttpClient client = new HttpClient();
    
    protected async void btnLogin_Click(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text;
        string password = txtPassword.Text;

        // URL del servicio (reemplazar con la ruta de tu API de Usuarios)
        string url = $"http://localhost:5000/api/Usuario/{usuario}/{password}";
        
        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                // Inicio de sesión exitoso, redirigir al menú principal
                Response.Redirect("MenuPrincipal.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = "Error al conectar con el servidor: " + ex.Message;
        }
    }
}
