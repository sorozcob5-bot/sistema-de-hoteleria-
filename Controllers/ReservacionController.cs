using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SistemaHoteleriaService.Data;
using SistemaHoteleriaService.Models;

[Route("api/[controller]")]
[ApiController]
public class ReservacionController : ControllerBase
{
    private readonly ConexionMysql _conexion;
    public ReservacionController(ConexionMysql conexion) { _conexion = conexion; }

    [HttpPost]
    public IActionResult Post([FromBody] Reservacion r)
    {
        try
        {
            using (var conn = _conexion.Conectar())
            {
                string sql = "INSERT INTO Reservacion (Fecha_Registro, Fecha_Entrada, Fecha_Salida, Total_Pagar, Id_Cliente, Id_Empleado) " +
                             "VALUES (NOW(), @entrada, @salida, @total, @cliente, @empleado)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@entrada", r.Fecha_Entrada);
                cmd.Parameters.AddWithValue("@salida", r.Fecha_Salida);
                cmd.Parameters.AddWithValue("@total", r.Total_Pagar);
                cmd.Parameters.AddWithValue("@cliente", r.Id_Cliente);
                cmd.Parameters.AddWithValue("@empleado", r.Id_Empleado);
                cmd.ExecuteNonQuery();
            }
            return Ok("Reservación creada con éxito.");
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
        finally { _conexion.Desconectar(); }
    }
}
