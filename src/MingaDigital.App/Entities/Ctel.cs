using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Ctel
    {
        public Int32 CtelId { get; set; }
        
        public Int32 UnidadEducativaId { get; set; }
        
        public virtual UnidadEducativa UnidadEducativa { get; set; }
    }
}
