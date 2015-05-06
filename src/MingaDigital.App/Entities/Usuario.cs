using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public abstract class Usuario
    {
        public Int32 UsuarioId { get; set; }
        
        [Required]
        [Index(IsUnique = true)]
        public String Username { get; set; }
        
        public Password Password { get; set; }
        
        public virtual ICollection<PermisoGlobal> PermisosGlobales { get; set; }
    }
}