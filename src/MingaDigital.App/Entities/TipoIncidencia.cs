using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class TipoIncidencia
    {
        public Int32 TipoIncidenciaId { get; set; }
        
        [Required]
        [Index(IsUnique = true)]
        public String Nombre { get; set; }
    }
}
