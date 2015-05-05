using System;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class UnidadEducativa
    {
        public Int32 UnidadEducativaId { get; set; }
        
        public String Nombre { get; set; }
        
        public Int32 UbicacionId { get; set; }

        public Int32 TelecentroId { get; set; }
        
        public virtual Ubicacion Ubicacion { get; set; }

        [ForeignKey(nameof(TelecentroId))]
        public virtual Telecentro Telecentro { get; set; }
    }
}