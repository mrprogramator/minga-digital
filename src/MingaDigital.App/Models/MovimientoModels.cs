using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Mvc;

namespace MingaDigital.App.Models
{
    public class MovimientoCreateStepOneModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Origen")]
        public EstablecimientoMingaSelector Origen { get; set; }
            = new EstablecimientoMingaSelector();

        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Destino")]
        public EstablecimientoMingaSelector Destino { get; set; }
            = new EstablecimientoMingaSelector();
    }

    public class MovimientoCreateStepTwoModel
    {
        public String OrigenNombre { get; set; }

        public String DestinoNombre { get; set; }

    }

    public class MovimientoCreateStepTwoItemModel
    {
        public Int32 ActivoMingaId { get; set; }

        public String Nombre { get; set; }

        public Boolean IsSelected { get; set; }

    }
}