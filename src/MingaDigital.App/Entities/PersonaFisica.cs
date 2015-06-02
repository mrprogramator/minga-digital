using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class PersonaFisica
    {
        public Int32 PersonaFisicaId { get; set; }
        
        [Required]
        public String Nombres { get; set; }
        
        [Required]
        public String Apellidos { get; set; }
        
        [NotMapped]
        public String Nombre => $"{Nombres} {Apellidos}";
        
        public String Nit { get; set; }
        
        public String Direccion { get; set; }
        
        public virtual Usuario Usuario { get; set; }
    }
}