using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Rol
    {
        public Int32 RolId { get; set; }
        
        public String Nombre { get; set; }
    }
}