using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class UsuarioPersonaJuridica : Usuario
    {
        [Index(IsUnique = true)]
        public Int32 PersonaJuridicaId { get; set; }
        
        
        public virtual PersonaJuridica PersonaJuridica { get; set; }
    }
}