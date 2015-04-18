using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Componente : ActivoMinga
    {
        public Int32 Id { get; set; }
        
        public TipoComponente Tipo { get; set; }
        
        public String Marca { get; set; }
        
        public String Caracteristica { get; set; }
        
        public Int32 EquipoId { get; set; }
        
        public virtual Equipo Equipo { get; set; }
    }
}
