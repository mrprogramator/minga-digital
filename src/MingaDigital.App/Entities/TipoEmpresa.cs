using System;

using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Entities
{
    public class TipoEmpresa
    {
        public Int32 TipoEmpresaId { get; set; }
        
        [Required]
        public String Nombre { get; set; }
    }
}