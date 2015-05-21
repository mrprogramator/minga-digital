using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Personas Físicas")]
    public class PersonaFisicaIndexModel : BasicIndexModel<PersonaFisicaIndexTableRow>
    {
    }
    
    public class PersonaFisicaIndexTableRow
    {
        public Int32 PersonaId { get; set; }
        
        [Display(Name = "Nombres")]
        public String Nombres { get; set; }
        
        [Display(Name = "Apellidos")]
        public String Apellidos { get; set; }
    }
    
    [Description("Persona Física")]
    public class PersonaFisicaDetailModel
    {
        public Int32 PersonaId { get; set; }
        
        [Display(Name = "Nombres")]
        public String Nombres { get; set; }
        
        [Display(Name = "Apellidos")]
        public String Apellidos { get; set; }
    }
    
    [Description("Persona Física")]
    public class PersonaFisicaEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombres")]
        public String Nombres { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Apellidos")]
        public String Apellidos { get; set; }
    }
}