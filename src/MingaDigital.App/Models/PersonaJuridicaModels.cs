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
        [Display(Name = "Rubro")]
        [AdditionalMetadata("Controller",   "RubroApi")]
        [AdditionalMetadata("Action",       nameof(RubroApiController.NameSearch))]
        [AdditionalMetadata("SearchKey",    nameof(RubroNameSearchApiModel.RubroId))]
        [AdditionalMetadata("SearchValue",  nameof(RubroNameSearchApiModel.Nombre))]
        public EntitySelectorModel Rubro { get; set; }
        
        public String RubroNombre { get; set; }
    }
}