namespace SistemaHoteleriaService.Models{
    public class DetalleReservacion{
        public int Id_Detalle { get; set; }
        public int Id_Reserva { get; set; }
        public int Id_Habitacion { get; set; }
        public int Noches_Reservadas { get; set; }
        public decimal Subtotal { get; set; }
    }
}