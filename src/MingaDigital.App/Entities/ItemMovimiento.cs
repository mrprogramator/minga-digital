using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class ItemMovimiento
    {
        public Int32 MovimientoId { get; set; }
        
        public Int32 ActivoMingaId { get; set; }
        
        public virtual Movimiento Movimiento { get; set; }
        
        public virtual ActivoMinga Activo { get; set; }
    }
}
