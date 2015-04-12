using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class EstadoTicket
    {
        public Int32 Id { get; set; }
        
        [Required]
        public String Nombre { get; set; }
    }
}
