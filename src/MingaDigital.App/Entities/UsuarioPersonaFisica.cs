using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class UsuarioPersonaFisica : Usuario
    {
        [Index(IsUnique = true)]
        public Int32 PersonaFisicaId { get; set; }
        
        public virtual PersonaFisica PersonaFisica { get; set; }
    }
}