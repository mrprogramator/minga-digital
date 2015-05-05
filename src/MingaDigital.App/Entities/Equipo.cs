using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Equipo : ActivoMinga
    {
        public Int32 EquipoId { get; set; }
        
        public String Detalle { get; set; }
        
        public EstadoEquipo Estado { get; set; }
    }
}
