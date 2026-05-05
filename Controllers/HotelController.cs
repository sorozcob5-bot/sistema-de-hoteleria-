using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SistemaHoteleriaService.Data;
using SistemaHoteleriaService.Models;

[Route("api/[controller]")]
[ApiController]
public class HotelController : ControllerBase
{
    private readonly ConexionMysql _conexion;
    public HotelController(ConexionMysql conexion) { _conexion = conexion; }

    [HttpGet]
    public IActionResult Get()
    {
        List<Hotel> lista = new List<Hotel>();
        try
        {
            using (var conn = _conexion.Conectar())
            {
                string sql = "SELECT * FROM Hotel";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Hotel
                        {
                            Id_Hotel = Convert.ToInt32(reader["Id_Hotel"]),
                            Nombre = reader["Nombre"].ToString()
                        });
                    }
                }
            }
            return Ok(lista);
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
        finally { _conexion.Desconectar(); }
    }
}