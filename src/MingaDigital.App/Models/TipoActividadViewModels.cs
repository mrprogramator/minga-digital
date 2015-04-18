using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Mvc.Rendering;

namespace MingaDigital.App.Models
{
    public class TipoActividadCreateViewModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        public String Descripcion { get; set; }
    }
}