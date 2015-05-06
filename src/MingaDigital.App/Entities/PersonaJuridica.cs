using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class PersonaJuridica
    {
        public Int32 PersonaJuridicaId { get; set; }
        
        [Required]
        public String Nombre { get; set; }
    }
}