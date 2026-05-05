using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SistemaHoteleriaService.Data;
using SistemaHoteleriaService.Models;
using System.Data;

namespace SistemaHoteleriaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ConexionMysql _conexion;

        public UsuarioController(ConexionMysql conexion)
        {
            _conexion = conexion;
        }

        
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Usuario login)
        {
            try
            {
                using (var conn = _conexion.Conectar())
                {
                    
                    string sql = "SELECT * FROM Usuario WHERE Username = @user AND Password = @pass";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user", login.Username);
                    cmd.Parameters.AddWithValue("@pass", login.Password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            return Ok(new
                            {
                                mensaje = "Bienvenido",
                                usuario = reader["Username"].ToString(),
                                rol = reader["Rol"].ToString()
                            });
                        }
                        else
                        {
                            
                            return Unauthorized("Usuario o contraseña incorrectos.");
                        }
                    }
                }
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