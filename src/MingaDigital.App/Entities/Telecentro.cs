using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Telecentro : EstablecimientoMinga
    {
        public Int32 TelecentroId { get; set; }
        
        public Int32 EstadoId { get; set; }
        
        public Nullable<Int32> PatrocinadorId { get; set; }
        
        public virtual EstadoTelecentro Estado { get; set; }
        
        [ForeignKey(nameof(PatrocinadorId))]
        public virtual PersonaJuridica Patrocinador { get; set; }

        public virtual ICollection<UnidadEducativa> UnidadesEducativas { get; set; }
    }
}
