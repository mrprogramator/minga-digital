using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Tipos de Componentes")]
    public class TipoComponenteIndexModel : BasicIndexModel<TipoComponenteIndexTableRow>
    {
    }
    
    public class TipoComponenteIndexTableRow
    {
        public Int32 TipoComponenteId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
        
    }
    
    [Description("Tipos de Componente")]
    public class TipoComponenteDetailModel
    {
        public Int32 TipoComponenteId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
        
    }
    
    [Description("Tipo de Componente")]
    public class TipoComponenteEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
}