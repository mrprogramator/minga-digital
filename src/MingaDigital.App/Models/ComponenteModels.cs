using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Componentes")]
    public class ComponenteIndexModel : BasicIndexModel<ComponenteIndexTableRow>
    {
    }
    
    public class ComponenteIndexTableRow
    {
        public Int32 ComponenteId { get; set; }
        
        [Display(Name = "Tipo-Componente")]
        public String TipoComponente { get; set; }
        
        [Display(Name = "Marca")]
        public String Marca { get; set; }
        
        [Display(Name = "Caracteristicas")]
        public String Caracteristica { get; set; }
        
        [Display(Name = "Equipo")]
        public Int32 EquipoId { get; set; }
    }
    
    [Description("Componente")]
    public class ComponenteDetailModel
    {
        public Int32 ComponenteId { get; set; }
        
        [Display(Name = "Tipo-Componente")]
        public String TipoComponente { get; set; }
        
        [Display(Name = "Marca")]
        public String Marca { get; set; }
        
        [Display(Name = "Caracteristicas")]
        public String Caracteristica { get; set; }
        
        [Display(Name = "Equipo")]
        public Int32 EquipoId { get; set; }
    }
    
    [Description("Componente")]
    public class ComponenteEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Tipo de Componente")]
        public Int32 TipoComponenteId { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Marca")]
        public String Marca { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Caracteristicas")]
        public String Caracteristica { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Equipo")]
        public Nullable<Int32> EquipoId { get; set; }
    }
}