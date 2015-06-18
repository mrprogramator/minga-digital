using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MingaDigital.App.ApiControllers;
using MingaDigital.App.Metadata;

namespace MingaDigital.App.Models
{
    [Description("Tickets")]
    public class TicketIndexModel : BasicIndexModel<TicketIndexTableRow>
    {
    }

    public class TicketIndexTableRow
    {
        public Int32 TicketId { get; set; }

        [Display(Name = "Tipo")]
        public String TipoIncidenciaNombre { get; set; }
    }

    [Description("Ticket")]
    public class TicketDetailModel
    {
        public Int32 TicketId { get; set; }
    }

    [Description("Ticket")]
    public class TicketEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Tipo de Incidencia")]
        public TipoIncidenciaSelector TipoIncidencia { get; set; }
            = new TipoIncidenciaSelector();

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }

        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Telecentro")]
        public Int32 Telecentro { get; set; }

        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Equipo")]
        public Int32 Equipo { get; set; }
    }
}
