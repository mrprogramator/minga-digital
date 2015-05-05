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
        public String Nombre { get; set; }
        
        public Int32 AreaId { get; set; }
        
        [ForeignKey(nameof(AreaId))]
        public virtual AreaIncidencia Area { get; set; }
    }
}
