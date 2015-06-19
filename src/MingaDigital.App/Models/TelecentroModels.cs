using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MingaDigital.App.ApiControllers;
using MingaDigital.App.Metadata;
using MingaDigital.App.Entities;

namespace MingaDigital.App.Models
{
    [Description("Telecentros")]
    public class TelecentroIndexModel : BasicIndexModel<TelecentroIndexTableRow>
    {
    }

    public class TelecentroIndexTableRow
    {
        public Int32 EstablecimientoMingaId { get; set; }

        [Display(Name = "Nombre")]
        public String Nombre { get; set; }

        [Display(Name = "Patrocinador")]
        public String Patrocinador { get; set; }

        [Display(Name = "Proveedor-Internet")]
        public String ProveedorInternet { get; set; }

        [Display(Name = "Ubicacion")]
        public String Ubicacion { get; set; }

        [Display(Name = "Estado")]
        public String Estado { get; set; }
    }

    [Description("Telecentro")]
    public class TelecentroDetailModel
    {
        public Int32 EstablecimientoMingaId { get; set; }

        [Display(Name = "Nombre")]
        public String Nombre { get; set; }

        [Display(Name = "Patrocinador")]
        public String Patrocinador { get; set; }

        [Display(Name = "Proveedor-Internet")]
        public String ProveedorInternet { get; set; }

        [Display(Name = "Ubicacion")]
        public String Ubicacion { get; set; }

        [Display(Name = "Estado")]
        public String Estado { get; set; }
    }

    [Description("Telecentro")]
    public class TelecentroEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }

        [Display(Name = "Patrocinador")]
        public Nullable<Int32> PatrocinadorId { get; set; }

        [Display(Name = "Proveedor Internet")]
        public Nullable<Int32> ProveedorInternetId { get; set; }

        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Ubicacion")]
        public UbicacionSelector Ubicacion { get; set; }
            = new UbicacionSelector();

        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Estado")]
        public EstadoTelecentro Estado { get; set; }
    }

    [AdditionalMetadata("Controller", "TelecentroApi")]
    [AdditionalMetadata("Action", nameof(TelecentroApiController.NameSearch))]
    public class TelecentroSelector : EntitySelector<Entities.Telecentro, Int32?>
    {
        public override String DisplayValue => Entity?.Nombre;

        public static implicit operator TelecentroSelector(Entities.Telecentro entity) =>
            new TelecentroSelector
            {
                Entity = entity,
                Key = entity.EstablecimientoMingaId
            };
    }
}
