using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Ubicacion
    {
        public Int32 Id { get; set; }
        
        public Int32 MunicipioId { get; set; }
        
        public Int32 Distrito { get; set; }
        
        public Int32 UnidadVecinal { get; set; }
        
        public String Direccion { get; set; }
        
        public GeoCoordenada Coordenada { get; set; }
        
        public virtual Municipio Municipio { get; set; }
    }
}