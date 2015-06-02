using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MingaDigital.Security;

namespace MingaDigital.App.Entities
{
    public class Usuario
    {
        // Sirve de FK para PersonaFisica
        public Int32 UsuarioId { get; set; }
        
        [Required]
        [Index(IsUnique = true)]
        public String Username { get; set; }
        
        [Required]
        public Password Password { get; set; }
        
        public virtual PersonaFisica PersonaFisica { get; set; }
        
        public virtual ICollection<PermisoGlobal> PermisosGlobales { get; set; }
    }
}