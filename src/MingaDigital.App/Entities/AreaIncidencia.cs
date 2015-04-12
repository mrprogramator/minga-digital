using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    [Table("area_incidencia")]
    public class AreaIncidencia
    {
        public Int32 Id { get; set; }
        
        public String Nombre { get; set; }
    }
}
