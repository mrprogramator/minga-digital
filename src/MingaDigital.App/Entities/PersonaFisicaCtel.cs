using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class PersonaFisicaCtel
    {
        [Key, Column(Order = 1)]
        public Int32 PersonaFisicaId { get; set; }
        
        [Key, Column(Order = 2)]
        public Int32 CtelId { get; set; }
        
        public virtual PersonaFisica PersonaFisica { get; set; }
        
        public virtual Ctel Ctel { get; set; }
    }
}
