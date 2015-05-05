using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public abstract class ActivoMinga
    {
        public Int32 ActivoMingaId { get; set; }
        
        public Int32 EstablecimientoId { get; set; }
        
        [ForeignKey(nameof(EstablecimientoId))]
        public virtual EstablecimientoMinga Establecimiento { get; set; }
    }
}
