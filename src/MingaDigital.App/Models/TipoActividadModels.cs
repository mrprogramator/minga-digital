using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Mvc.Rendering;

namespace MingaDigital.App.Models
{
    [Description("Tipos de Actividad")]
    public class TipoActividadIndexModel : BasicIndexModel<TipoActividadIndexTableRow>
    {
    }
    
    public class TipoActividadIndexTableRow
    {
        public Int32 TipoActividadId { get; set; }
        
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }
    }
    
    [Description("Tipo de Actividad")]
    public class TipoActividadDetailModel
    {
        public Int32 TipoActividadId { get; set; }
        
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }
    }
    
    [Description("Tipo de Actividad")]
    public class TipoActividadEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }
    }
}