using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

public partial class Habitaciones : System.Web.UI.Page
{
    // Cambia esto por la URL real de tu API de Hoteles
    private string urlApiHoteles = "http://tu-api.com/api/hoteles";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // RegisterAsyncTask permite llamar a métodos asíncronos en el Load
            RegisterAsyncTask(new PageAsyncTask(CargarHoteles));
        }
    }

    private async Task CargarHoteles()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(urlApiHoteles);
                var listaHoteles = new JavaScriptSerializer().Deserialize<List<HotelDTO>>(json);

                ddlHoteles.DataSource = listaHoteles;
                ddlHoteles.DataTextField = "nombre"; // Lo que el usuario ve
                ddlHoteles.DataValueField = "id";    // El ID que se guarda en la DB
                ddlHoteles.DataBind();

                // Añadir una opción por defecto
                ddlHoteles.Items.Insert(0, new ListItem("Seleccione un hotel...", "0"));
            }
        }
        catch (Exception)
        {
            ddlHoteles.Items.Add(new ListItem("Error al cargar hoteles", "0"));
        }
    }

    // Clase auxiliar para recibir los datos de la API
    public class HotelDTO {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    // ... aquí iría tu método btnGuardar_Click que ya tienes ...
}
