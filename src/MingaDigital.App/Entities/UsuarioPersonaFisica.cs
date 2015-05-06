using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class UsuarioPersonaFisica : Usuario
    {
        public Int32 PersonaFisicaId { get; set; }
        
        [Index(IsUnique = true)]
        public virtual PersonaFisica PersonaFisica { get; set; }
    }
}