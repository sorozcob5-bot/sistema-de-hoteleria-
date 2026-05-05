using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SistemaHoteleriaService.Data;
using SistemaHoteleriaService.Models;
using System.Data;

namespace SistemaHoteleriaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ConexionMysql _conexion;

        public ClienteController(ConexionMysql conexion)
        {
            _conexion = conexion;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                using (var conn = _conexion.Conectar())
                {
                    string sql = "SELECT * FROM Cliente";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cliente
                            {
                                Id_Cliente = Convert.ToInt32(reader["Id_Cliente"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Nit = reader["Nit"].ToString(),
                                Correo = reader["Correo"].ToString()
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
                _conexion.Desconectar();
            }
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] Cliente c)
        {
            try
            {
                using (var conn = _conexion.Conectar())
                {
                    string sql = "INSERT INTO Cliente (Nombre, Apellido, Nit, Correo) " +
                                 "VALUES (@nom, @ape, @nit, @correo)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nom", c.Nombre);
                    cmd.Parameters.AddWithValue("@ape", c.Apellido);
                    cmd.Parameters.AddWithValue("@nit", c.Nit);
                    cmd.Parameters.AddWithValue("@correo", c.Correo);
                    cmd.ExecuteNonQuery();
                }
                return Ok("Cliente registrado correctamente.");
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