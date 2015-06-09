using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Telecentros")]
    public class TelecentroIndexModel : BasicIndexModel<TelecentroIndexTableRow>
    {
    }
    
    public class TelecentroIndexTableRow
    {
        public Int32 EstablecimientoMingaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Telecentro")]
    public class TelecentroDetailModel
    {
        public Int32 EstablecimientoMingaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Telecentro")]
    public class TelecentroEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
}