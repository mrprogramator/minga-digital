using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class UsuarioPersonaJuridica : Usuario
    {
        public Int32 PersonaJuridicaId { get; set; }
        
        [Index(IsUnique = true)]
        public virtual PersonaJuridica PersonaJuridica { get; set; }
    }
}