using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class ItemMovimiento
    {
        [Key, Column(Order = 1)]
        public Int32 MovimientoId { get; set; }
        
        [Key, Column(Order = 2)]
        public Int32 ActivoMingaId { get; set; }
        
        public virtual Movimiento Movimiento { get; set; }
        
        public virtual ActivoMinga Activo { get; set; }
    }
}
