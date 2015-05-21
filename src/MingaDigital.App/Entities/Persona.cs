using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public abstract class Persona
    {
        public Int32 PersonaId { get; set; }
        
        [Required]
        public String Nombre { get; set; }
        
        public String Direccion { get; set; }
    }
}