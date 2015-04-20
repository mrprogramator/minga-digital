using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Mvc.Rendering;

namespace MingaDigital.App.Models
{
    public class TipoActividadDetailModel : TipoActividadEditorModel
    {
        public Int32 Id;
    }

    public class TipoActividadEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }
    }
}