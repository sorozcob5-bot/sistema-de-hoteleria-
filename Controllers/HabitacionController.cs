using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SistemaHoteleriaService.Data;
using SistemaHoteleriaService.Models;
using System.Data;

namespace SistemaHoteleriaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly ConexionMysql _conexion;

        public HabitacionController(ConexionMysql conexion)
        {
            _conexion = conexion;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            List<Habitacion> lista = new List<Habitacion>();
            try
            {
                using (var conn = _conexion.Conectar()) // ABRIR CONEXIÓN (Punto 3)
                {
                    string sql = "SELECT * FROM Habitacion";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Habitacion
                            {
                                Id_Habitacion = Convert.ToInt32(reader["Id_Habitacion"]),
                                Numero_Habitacion = reader["Numero_Habitacion"].ToString(),
                                Nivel = Convert.ToInt32(reader["Nivel"]),
                                Estado = reader["Estado"].ToString()
                            });
                        }
                    }
                }
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _conexion.Desconectar(); // DOBLE SEGURIDAD DE CIERRE
            }
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] Habitacion h)
        {
            try
            {
                using (var conn = _conexion.Conectar())
                {
                    string sql = "INSERT INTO Habitacion (Numero_Habitacion, Nivel, Estado, Id_Tipo, Id_Hotel) " +
                                 "VALUES (@num, @nivel, @estado, @tipo, @hotel)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@num", h.Numero_Habitacion);
                    cmd.Parameters.AddWithValue("@nivel", h.Nivel);
                    cmd.Parameters.AddWithValue("@estado", h.Estado);
                    cmd.Parameters.AddWithValue("@tipo", h.Id_Tipo);
                    cmd.Parameters.AddWithValue("@hotel", h.Id_Hotel);
                    cmd.ExecuteNonQuery();
                }
                return Ok("Habitación guardada con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _conexion.Desconectar();
            }
        }
    }
}
