using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Usuario")]
    public class UsuarioDetailModel
    {
        [Display(Name = "Persona Física")]
        public String PersonaFisicaNombre { get; set; }
        
        [Display(Name = "Username")]
        public String Username { get; set; }
    }
    
    [Description("Usuario")]
    public class UsuarioEditorModel
    {
        [ReadOnly(true)]
        [Display(Name = "Persona Física")]
        public String PersonaFisicaNombre { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Username")]
        public String Username { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}