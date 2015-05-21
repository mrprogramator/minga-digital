using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Roles")]
    public class RolIndexModel : BasicIndexModel<RolIndexTableRow>
    {
    }
    
    public class RolIndexTableRow
    {
        public Int32 RolId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Rol")]
    public class RolDetailModel
    {
        public Int32 RolId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Rol")]
    public class RolEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
}