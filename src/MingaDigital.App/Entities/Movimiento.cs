using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Movimiento
    {
        public Int32 MovimientoId { get; set; }
        
        public Int32 OrigenId { get; set; }
        
        public Int32 DestinoId { get; set; }
        
        public DateTimeOffset FechaHora { get; set; }
        
        [ForeignKey(nameof(OrigenId))]
        public virtual EstablecimientoMinga Origen { get; set; }
        
        [ForeignKey(nameof(DestinoId))]
        public virtual EstablecimientoMinga Destino { get; set; }
        
        // public Persona Encargado { get; set; }
    }
}
