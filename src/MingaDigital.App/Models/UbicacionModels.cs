using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using MingaDigital.App.Entities;

namespace MingaDigital.App.Models
{
    public class UbicacionEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Municipio")]
        public Int32 MunicipioId { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Distrito")]
        public Int32 Distrito { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Unidad Vecinal")]
        public Int32 UnidadVecinal { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Direccion")]
        public String Direccion { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Coordenada")]
        public GeoCoordenada Coordenada { get; set; }
    }
}