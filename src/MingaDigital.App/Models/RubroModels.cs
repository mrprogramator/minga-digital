using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Microsoft.Framework.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding.Validation;

using MingaDigital.App.EF;
using MingaDigital.App.ApiModels;
using MingaDigital.App.ApiControllers;
using MingaDigital.App.Metadata;

namespace MingaDigital.App.Models
{
    [Description("Rubros")]
    public class RubroIndexModel : BasicIndexModel<RubroIndexTableRow>
    {
    }
    
    public class RubroIndexTableRow
    {
        public Int32 RubroId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Rubro")]
    public class RubroDetailModel
    {
        public Int32 RubroId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Rubro")]
    public class RubroEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [AdditionalMetadata("Controller", "RubroApi")]
    [AdditionalMetadata("Action", nameof(RubroApiController.NameSearch))]
    public class RubroSelector : EntitySelector<Entities.Rubro, Int32?>
    {
        public override String DisplayValue => Entity?.Nombre;
        
        public static implicit operator RubroSelector(Entities.Rubro entity) =>
            new RubroSelector
            {
                Entity = entity,
                Key = entity.RubroId
            };
    }
}