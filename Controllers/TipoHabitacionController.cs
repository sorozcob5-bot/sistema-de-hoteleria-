using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SistemaHoteleriaService.Data;
using SistemaHoteleriaService.Models;

[Route("api/[controller]")]
[ApiController]
public class TipoHabitacionController : ControllerBase
{
    private readonly ConexionMysql _conexion;
    public TipoHabitacionController(ConexionMysql conexion) { _conexion = conexion; }

    [HttpGet]
    public IActionResult Get()
    {
        List<TipoHabitacion> lista = new List<TipoHabitacion>();
        try
        {
            using (var conn = _conexion.Conectar())
            {
                string sql = "SELECT * FROM TipoHabitacion";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new TipoHabitacion
                        {
                            Id_Tipo = Convert.ToInt32(reader["Id_Tipo"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            Precio_Base = Convert.ToDecimal(reader["Precio_Base"])
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