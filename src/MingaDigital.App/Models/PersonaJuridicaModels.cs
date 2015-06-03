using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MingaDigital.App.ApiModels;
using MingaDigital.App.ApiControllers;
using MingaDigital.App.Metadata;

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
        
        [Display(Name = "Rubro")]
        [UIHint("EntitySelector")]
        public RubroEntitySelectorModel Rubro { get; set; }
            = new RubroEntitySelectorModel();
        
        [Display(Name = "Tipo de Empresa")]
        [UIHint("EntitySelector")]
        public TipoEmpresaEntitySelectorModel TipoEmpresa { get; set; }
            = new TipoEmpresaEntitySelectorModel();
        
        [Display(Name = "Encargado")]
        [UIHint("EntitySelector")]
        public PersonaFisicaEntitySelectorModel Encargado { get; set; }
            = new PersonaFisicaEntitySelectorModel();
    }
}