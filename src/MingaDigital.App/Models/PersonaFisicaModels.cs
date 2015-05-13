using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    public class PersonaFisicaIndexModel
    {
        public PersonaFisicaIndexTable Table { get; set; }
    }
    
    public class PersonaFisicaIndexTable : BasicTable<PersonaFisicaIndexTableRow>
    {
    }
    
    public class PersonaFisicaIndexTableRow
    {
        public Int32 PersonaFisicaId { get; set; }
        
        [Display(Name = "Nombres")]
        public String Nombres { get; set; }
        
        [Display(Name = "Apellidos")]
        public String Apellidos { get; set; }
    }
    
    public class PersonaDetailModel : PersonaEditorModel
    {
        public Int32 PersonaFisicaId { get; set; }
    }
    
    public class PersonaEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombres")]
        public String Nombres { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Apellidos")]
        public String Apellidos { get; set; }
    }
}