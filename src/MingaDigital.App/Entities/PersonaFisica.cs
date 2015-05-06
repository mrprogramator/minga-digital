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
    }
}