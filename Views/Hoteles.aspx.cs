using System;
using System.Net.Http;
using System.Text;
using System.Web.UI;
using System.Web.Script.Serialization; // Para manejar JSON

public partial class Hoteles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Aquí llamarías a un método para cargar los hoteles en el GridView
        }
    }

    protected async void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            var hotel = new {
                nombre = txtNombre.Text,
                direccion = txtDireccion.Text,
                telefono = txtTelefono.Text
            };

            using (HttpClient client = new HttpClient())
            {
                var json = new JavaScriptSerializer().Serialize(hotel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // REEMPLAZA ESTA URL POR LA DE TU API REAL
                var response = await client.PostAsync("http://tu-api.com/api/hoteles", content);

                if (response.IsSuccessStatusCode)
                {
                    // Lógica para limpiar campos y avisar al usuario
                    txtNombre.Text = ""; txtDireccion.Text = ""; txtTelefono.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            // Manejo de errores
        }
    }
}
