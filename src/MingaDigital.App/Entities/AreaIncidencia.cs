using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class AreaIncidencia
    {
        public Int32 AreaIncidenciaId { get; set; }
        
        [Required]
        public String Nombre { get; set; }
    }
}
