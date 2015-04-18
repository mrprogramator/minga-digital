using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public abstract class ActivoMinga
    {
        public Int32 Id { get; set; }
        
        public Int32 EstablecimientoId { get; set; }
        
        public virtual EstablecimientoMinga Establecimiento { get; set; }
    }
}
