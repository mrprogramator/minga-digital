using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Tipos de Empresa")]
    public class TipoEmpresaIndexModel : BasicIndexModel<TipoEmpresaIndexTableRow>
    {
    }
    
    public class TipoEmpresaIndexTableRow
    {
        public Int32 TipoEmpresaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Tipo de Empresa")]
    public class TipoEmpresaDetailModel
    {
        public Int32 TipoEmpresaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Tipo de Empresa")]
    public class TipoEmpresaEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
}