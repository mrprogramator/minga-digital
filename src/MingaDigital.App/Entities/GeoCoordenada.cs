using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    [ComplexType]
    public class GeoCoordenada
    {
        public Decimal Latitud { get; set; }
        
        public Decimal Longitud { get; set; }
    }
}