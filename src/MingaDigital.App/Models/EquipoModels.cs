using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MingaDigital.App.ApiControllers;
using MingaDigital.App.Metadata;
using MingaDigital.App.Entities;

namespace MingaDigital.App.Models
{
    [Description("Equipos")]
    public class EquipoIndexModel : BasicIndexModel<EquipoIndexTableRow>
    {
    }

    public class EquipoIndexTableRow
    {
        public Int32 ActivoMingaId { get; set; }

        [Display(Name = "Detalle")]
        public String Detalle { get; set; }

        [Display(Name = "Estado")]
        public Int32 Estado { get; set; }
    }

    [Description("Equipo")]
    public class EquipoDetailModel
    {
        public Int32 ActivoMingaId { get; set; }

        [Display(Name = "Detalle")]
        public String Detalle { get; set; }

        [Display(Name = "Estado")]
        public Int32 Estado { get; set; }

    }

    [Description("Equipo")]
    public class EquipoEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Detalle")]
        public String Detalle { get; set; }

        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Estado")]
        public EstadoEquipo Estado { get; set; }

        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Establecimiento")]
        public EstablecimientoMingaSelector Establecimiento { get; set; }
            = new EstablecimientoMingaSelector();
    }

    [AdditionalMetadata("Controller", "EquipoApi")]
    [AdditionalMetadata("Action", nameof(EquipoApiController.NameSearch))]
    public class EquipoSelector : EntitySelector<Entities.Equipo, Int32?>
    {
        public override String DisplayValue => Entity?.Detalle;

        public static implicit operator EquipoSelector(Entities.Equipo entity) =>
            new EquipoSelector
            {
                Entity = entity,
                Key = entity.ActivoMingaId
            };
    }
}
