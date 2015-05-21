using System;

namespace MingaDigital.App.Entities
{
    public abstract class Persona
    {
        public Int32 PersonaId { get; set; }
        
        public virtual Usuario Usuario { get; set; }
    }
}