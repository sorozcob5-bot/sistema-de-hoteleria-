namespace SistemaHoteleriaService.Models{
    public class Usuario{
        public int Id_Usuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; } 
        public int Id_Empleado { get; set; }
    }
}