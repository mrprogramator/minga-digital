using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Almacen : EstablecimientoMinga
    {
        public Int32 AlmacenId { get; set; }
    }
}
