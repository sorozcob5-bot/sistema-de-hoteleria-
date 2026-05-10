using System;
using System.Net.Http;
using System.Text;
using System.Web.UI;
using System.Web.Script.Serialization;

public partial class Habitaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Aquí llamarías a la API para llenar el ddlHoteles
        }
    }

    protected async void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            var habitacion = new {
                id_hotel = ddlHoteles.SelectedValue,
                numero = txtNumero.Text,
                tipo = ddlTipo.SelectedValue,
                precio = txtPrecio.Text
            };

            using (HttpClient client = new HttpClient())
            {
                var json = new JavaScriptSerializer().Serialize(habitacion);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                // REEMPLAZAR CON TU URL DE API
                var response = await client.PostAsync("http://tu-api.com/api/habitaciones", content);

                if (response.IsSuccessStatusCode) {
                    // Limpiar campos
                    txtNumero.Text = ""; txtPrecio.Text = "";
                }
            }
        }
        catch (Exception ex) { /* Manejar error */ }
    }
}
