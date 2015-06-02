using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Rubros")]
    public class RubroIndexModel : BasicIndexModel<RubroIndexTableRow>
    {
    }
    
    public class RubroIndexTableRow
    {
        public Int32 RubroId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Rubro")]
    public class RubroDetailModel
    {
        public Int32 RubroId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Rubro")]
    public class RubroEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
}