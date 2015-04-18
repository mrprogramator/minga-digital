using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Telecentro : EstablecimientoMinga
    {
        public Int32 Id { get; set; }
        
        public Int32 EstadoId { get; set; }
        
        public Int32 PatrocinadorId { get; set; }
        
        public virtual EstadoTelecentro Estado { get; set; }
        
        public virtual PersonaJuridica Patrocinador { get; set; }
    }
}
