using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public abstract class EstablecimientoMinga
    {
        public Int32 EstablecimientoMingaId { get; set; }
        
        [Required]
        [Index(IsUnique = true)]
        public String Nombre { get; set; }
        
        public Int32 UbicacionId { get; set; }
        
        public virtual Ubicacion Ubicacion { get; set; }
    }
}