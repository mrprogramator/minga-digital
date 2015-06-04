using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Tipos de Incidencias")]
    public class TipoIncidenciaIndexModel : BasicIndexModel<TipoIncidenciaIndexTableRow>
    {
    }
    
    public class TipoIncidenciaIndexTableRow
    {
        public Int32 TipoIncidenciaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Tipo de Incidencia")]
    public class TipoIncidenciaDetailModel
    {
        public Int32 TipoIncidenciaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Tipo de Incidencia")]
    public class TipoIncidenciaEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
}