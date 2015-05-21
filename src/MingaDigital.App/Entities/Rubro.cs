using System;

using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Entities
{
    public class Rubro
    {
        public Int32 RubroId { get; set; }
        
        [Required]
        public String Nombre { get; set; }
    }
}