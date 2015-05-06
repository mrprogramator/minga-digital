using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Componente : ActivoMinga
    {
        public Int32 ComponenteId { get; set; }

        public Int32 TipoComponenteId { get; set; }
        
        public String Marca { get; set; }
        
        public String Caracteristica { get; set; }
        
        public Nullable<Int32> EquipoId { get; set; }
        
        public virtual TipoComponente TipoComponente { get; set; }

        [ForeignKey(nameof(EquipoId))]
        public virtual Equipo Equipo { get; set; }
    }
}
