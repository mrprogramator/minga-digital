using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Telecentro : EstablecimientoMinga
    {
        public Nullable<Int32> PatrocinadorId { get; set; }

        public Nullable<Int32> ProveedorInternetId { get; set; }
        
        public EstadoTelecentro Estado { get; set; }
        
        [ForeignKey(nameof(PatrocinadorId))]
        public virtual PersonaJuridica Patrocinador { get; set; }

        [ForeignKey(nameof(ProveedorInternetId))]
        public virtual PersonaJuridica ProveedorInternet { get; set; }
        
        public virtual ICollection<UnidadEducativa> UnidadesEducativas { get; set; }
    }
}
