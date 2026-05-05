using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaHoteleriaService.Data{
    public class ConexionMysql    {
        private readonly string _connectionString;
        private MySqlConnection _conexion;

        public ConexionMysql(IConfiguration configuration)        {
            
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _conexion = new MySqlConnection(_connectionString);
        }

         public MySqlConnection Conectar()        {
            if (_conexion.State != ConnectionState.Open){
                _conexion.Open();
            }
            return _conexion;
        }
              
        public void Desconectar(){
            if (_conexion.State != ConnectionState.Closed){
                _conexion.Close();
            }
        }
    }
}