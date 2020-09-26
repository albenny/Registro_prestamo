using System;
using System.ComponentModel.DataAnnotations;

namespace Registro_prestamo.Entidades
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int PersonaId { get; set; }
        public string Concepto { get; set; }
        public double Monto { get; set; }
        public double Balance { get; set; }
    }
}