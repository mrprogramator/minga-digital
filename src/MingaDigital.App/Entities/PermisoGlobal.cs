using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class PermisoGlobal
    {
        [Required]
        [Key, Column(Order = 1)]
        public String AccionId { get; set; }
        
        [Key, Column(Order = 2)]
        public Int32 UsuarioId { get; set; }
        
        public virtual Accion Accion { get; set; }
        
        public virtual Usuario Usuario { get; set; }
    }
}