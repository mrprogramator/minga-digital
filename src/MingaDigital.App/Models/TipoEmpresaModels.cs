using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MingaDigital.App.ApiControllers;
using MingaDigital.App.Metadata;

namespace MingaDigital.App.Models
{
    [Description("Tipos de Empresa")]
    public class TipoEmpresaIndexModel : BasicIndexModel<TipoEmpresaIndexTableRow>
    {
    }
    
    public class TipoEmpresaIndexTableRow
    {
        public Int32 TipoEmpresaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Tipo de Empresa")]
    public class TipoEmpresaDetailModel
    {
        public Int32 TipoEmpresaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Tipo de Empresa")]
    public class TipoEmpresaEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [AdditionalMetadata("Controller", "TipoEmpresaApi")]
    [AdditionalMetadata("Action", nameof(TipoEmpresaApiController.NameSearch))]
    public class TipoEmpresaSelector : EntitySelector<Entities.TipoEmpresa, Int32?>
    {
        public override String DisplayValue => Entity?.Nombre;
        
        public static implicit operator TipoEmpresaSelector(Entities.TipoEmpresa entity) =>
            new TipoEmpresaSelector
            {
                Entity = entity,
                Key = entity.TipoEmpresaId
            };
    }
}