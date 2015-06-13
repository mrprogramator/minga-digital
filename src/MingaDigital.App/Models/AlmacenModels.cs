using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Almacenes")]
    public class AlmacenIndexModel : BasicIndexModel<AlmacenIndexTableRow>
    {
    }
    
    public class AlmacenIndexTableRow
    {
        public Int32 EstablecimientoMingaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
        
        [Display(Name = "Ubicacion")]
        public String Ubicacion { get; set; }
    }
    
    [Description("Almacen")]
    public class AlmacenDetailModel
    {
        public Int32 EstablecimientoMingaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
        
        [Display(Name = "Ubicacion")]
        public String Ubicacion { get; set; }
    }
    
    [Description("Almacen")]
    public class AlmacenEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Ubicacion")]
        public Int32 UbicacionId { get; set; }
    }
}