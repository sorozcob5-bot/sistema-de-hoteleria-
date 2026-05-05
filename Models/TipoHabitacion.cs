namespace SistemaHoteleriaService.Models{
    public class TipoHabitacion{
        public int Id_Tipo { get; set; }
        public string Descripcion { get; set; } 
        public decimal Precio_Base { get; set; }
        public int Capacidad { get; set; }
    }
}
