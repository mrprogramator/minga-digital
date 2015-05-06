using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class TipoComponente
    {
        public Int32 TipoComponenteId { get; set; }

        [Index(IsUnique = true)]
        public String Nombre { get; set; }
    }
}
