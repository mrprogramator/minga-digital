using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    [Table("usuario_rol")]
    public class UsuarioRol
    {
        [Key, Column(Order = 1)]
        public Int32 UsuarioId { get; set; }
        
        [Key, Column(Order = 2)]
        public Int32 RolId { get; set; }
        
        public virtual Usuario Usuario { get; set; }
        
        public virtual Rol Rol { get; set; }
    }
}