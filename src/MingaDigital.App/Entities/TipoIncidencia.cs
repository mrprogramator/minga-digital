using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class TipoIncidencia
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
    }
}
