using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MingaDigital.App.ApiControllers;
using MingaDigital.App.Metadata;

namespace MingaDigital.App.Models
{
    [Description("Tipos de Incidencias")]
    public class TipoIncidenciaIndexModel : BasicIndexModel<TipoIncidenciaIndexTableRow>
    {
    }

    public class TipoIncidenciaIndexTableRow
    {
        public Int32 TipoIncidenciaId { get; set; }

        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }

    [Description("Tipo de Incidencia")]
    public class TipoIncidenciaDetailModel
    {
        public Int32 TipoIncidenciaId { get; set; }

        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }

    [Description("Tipo de Incidencia")]
    public class TipoIncidenciaEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }

    [AdditionalMetadata("Controller", "TipoIncidenciaApi")]
    [AdditionalMetadata("Action", nameof(TipoIncidenciaApiController.NameSearch))]
    public class TipoIncidenciaSelector : EntitySelector<Entities.TipoIncidencia, Int32?>
    {
        public override String DisplayValue => Entity?.Nombre;

        public static implicit operator TipoIncidenciaSelector(Entities.TipoIncidencia entity) =>
            new TipoIncidenciaSelector
            {
                Entity = entity,
                Key = entity.TipoIncidenciaId
            };
    }
}
