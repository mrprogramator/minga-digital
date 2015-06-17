using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Tipos de Componentes")]
    public class MunicipioIndexModel : BasicIndexModel<MunicipioIndexTableRow>
    {
    }
    
    public class MunicipioIndexTableRow
    {
        [Display(Name = "Codigo")]
        public Int32 MunicipioId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
        
    }
    
    [Description("Tipos de Componente")]
    public class MunicipioDetailModel
    {
        [Display(Name = "Codigo")]
        public Int32 MunicipioId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
        
    }
    
    [Description("Tipo de Componente")]
    public class MunicipioEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
}