using System;

namespace SistemaHoteleriaService.Models{
    public class Reservacion{
        public int Id_Reserva { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public DateTime Fecha_Entrada { get; set; }
        public DateTime Fecha_Salida { get; set; }
        public decimal Total_Pagar { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Empleado { get; set; }
    }
}