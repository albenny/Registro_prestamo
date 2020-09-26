using System;
using System.ComponentModel.DataAnnotations;

namespace Registro_prestamo.Entidades
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombres { get; set; }
        public double Balance { get; set; }
    }
}