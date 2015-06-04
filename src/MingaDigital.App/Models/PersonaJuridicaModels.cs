using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Personas Jurídicas")]
    public class PersonaJuridicaIndexModel : BasicIndexModel<PersonaJuridicaIndexTableRow>
    {
    }
    
    public class PersonaJuridicaIndexTableRow
    {
        public Int32 PersonaJuridicaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Persona Jurídica")]
    public class PersonaJuridicaDetailModel
    {
        public Int32 PersonaJuridicaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Persona Jurídica")]
    public class PersonaJuridicaEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "NIT")]
        public String Nit { get; set; }
        
        [Display(Name = "Dirección")]
        public String Direccion { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Rubro")]
        public RubroSelector Rubro { get; set; }
            = new RubroSelector();
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Tipo de Empresa")]
        public TipoEmpresaSelector TipoEmpresa { get; set; }
            = new TipoEmpresaSelector();
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Encargado")]
        public PersonaFisicaSelector Encargado { get; set; }
            = new PersonaFisicaSelector();
    }
}