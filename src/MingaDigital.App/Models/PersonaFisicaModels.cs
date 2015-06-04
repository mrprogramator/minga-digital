using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MingaDigital.App.ApiControllers;
using MingaDigital.App.Metadata;

namespace MingaDigital.App.Models
{
    [Description("Personas Físicas")]
    public class PersonaFisicaIndexModel : BasicIndexModel<PersonaFisicaIndexTableRow>
    {
    }
    
    public class PersonaFisicaIndexTableRow
    {
        public Int32 PersonaFisicaId { get; set; }
        
        [Display(Name = "Nombres")]
        public String Nombres { get; set; }
        
        [Display(Name = "Apellidos")]
        public String Apellidos { get; set; }
        
        [Display(Name = "NIT")]
        public String Nit { get; set; }
        
        public Nullable<Int32> UsuarioId { get; set; }
    }
    
    [Description("Persona Física")]
    public class PersonaFisicaDetailModel
    {
        public Int32 PersonaFisicaId { get; set; }
        
        [Display(Name = "Nombres")]
        public String Nombres { get; set; }
        
        [Display(Name = "Apellidos")]
        public String Apellidos { get; set; }
        
        [Display(Name = "NIT")]
        public String Nit { get; set; }
        
        [Display(Name = "Dirección")]
        public String Direccion { get; set; }
        
        public Nullable<Int32> UsuarioId { get; set; }
    }
    
    [Description("Persona Física")]
    public class PersonaFisicaEditorModel
    {
        public Nullable<Int32> PersonaFisicaId { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombres")]
        public String Nombres { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Apellidos")]
        public String Apellidos { get; set; }
        
        [Display(Name = "NIT")]
        public String Nit { get; set; }
        
        [Display(Name = "Dirección")]
        public String Direccion { get; set; }
    }
    
    [AdditionalMetadata("Controller", "PersonaFisicaApi")]
    [AdditionalMetadata("Action", nameof(PersonaFisicaApiController.NameSearch))]
    public class PersonaFisicaSelector : EntitySelector<Entities.PersonaFisica, Int32?>
    {
        public override String DisplayValue => Entity?.Nombre;
        
        public static implicit operator PersonaFisicaSelector(Entities.PersonaFisica entity) =>
            new PersonaFisicaSelector
            {
                Entity = entity,
                Key = entity.PersonaFisicaId
            };
    }
}