using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class TipoActividad
    {
        public Int32 Id { get; set; }

        [Required]
        public String Descripcion { get; set; }
        
        public virtual ICollection<Actividad> Actividades { get; set; }
    }
}