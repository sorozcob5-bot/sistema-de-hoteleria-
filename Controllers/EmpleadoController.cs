using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SistemaHoteleriaService.Data;
using SistemaHoteleriaService.Models;

namespace SistemaHoteleriaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly ConexionMysql _conexion;
        public EmpleadoController(ConexionMysql conexion) { _conexion = conexion; }

        [HttpGet]
        public IActionResult Get()
        {
            List<Empleado> lista = new List<Empleado>();
            try
            {
                using (var conn = _conexion.Conectar())
                {
                    string sql = "SELECT * FROM Empleado";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Empleado
                            {
                                Id_Empleado = Convert.ToInt32(reader["Id_Empleado"]),
                                Nombre = reader["Nombre"].ToString(),
                                Puesto = reader["Puesto"].ToString()
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
}