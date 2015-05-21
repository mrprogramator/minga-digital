using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class PersonaFisica : Persona
    {
        [Required]
        public String Nombres { get; set; }
        
        [Required]
        public String Apellidos { get; set; }
        
        public String Nit { get; set; }
        
        public virtual Usuario Usuario { get; set; }
    }
}