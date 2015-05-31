using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Usuario")]
    public class UsuarioDetailModel
    {
        public Int32 PersonaFisicaId { get; set; }
        
        [Display(Name = "Persona Física")]
        public String PersonaFisicaNombre { get; set; }
        
        [Display(Name = "Username")]
        public String Username { get; set; }
    }
    
    [Description("Password de Usuario")]
    public class UsuarioChangePasswordModel
    {
        [ReadOnly(true)]
        public Int32 UsuarioId { get; set; }
        
        [ReadOnly(true)]
        [Display(Name = "Persona Física")]
        public String PersonaFisicaNombre { get; set; }
        
        [ReadOnly(true)]
        [Display(Name = "Username")]
        public String Username { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
    
    [Description("Usuario")]
    public class UsuarioEditorModel
    {
        public Int32 PersonaFisicaId { get; set; }
        
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
    
    public class UsuarioLoginModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Username")]
        public String Username { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}