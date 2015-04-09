using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    [Table("usuario")]
    public class Usuario
    {
        public Int32 Id { get; set; }
        
        [Index(IsUnique = true)]
        public String Username { get; set; }
        
        public Password Password { get; set; }
        
        public virtual ICollection<Rol> Roles { get; set; }
        
        public virtual ICollection<PermisoGlobal> PermisosGlobales { get; set; }
    }
}