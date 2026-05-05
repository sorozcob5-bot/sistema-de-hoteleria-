namespace SistemaHoteleriaService.Models{
    public class Habitacion{
        public int Id_Habitacion { get; set; }
        public string Numero_Habitacion { get; set; }
        public int Nivel { get; set; }
        public string Estado { get; set; }
        public int Id_Tipo { get; set; }
        public int Id_Hotel { get; set; }
    }
}