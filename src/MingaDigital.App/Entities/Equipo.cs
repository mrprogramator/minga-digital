using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public abstract class Equipo : ActivoMinga
    {
        public Int32 Id { get; set; }
        
        public String Detalle { get; set; }
    }
}
