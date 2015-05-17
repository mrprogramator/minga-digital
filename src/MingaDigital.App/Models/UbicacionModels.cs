using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MingaDigital.App.Entities;

namespace MingaDigital.App.Models
{
    public class UbicacionIndexModel : BasicIndexModel<UbicacionIndexTableRow>
    {
    }
    
    [Description("Ubicación")]
    public class UbicacionIndexTableRow
    {
        public Int32 UbicacionId { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Municipio")]
        public String Municipio { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Distrito")]
        public Int32 Distrito { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Unidad Vecinal")]
        public Int32 UnidadVecinal { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Dirección")]
        public String Direccion { get; set; }
    }
    
    [Description("Ubicación")]
    public class UbicacionDetailModel
    {
        public Int32 UbicacionId { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Municipio")]
        public String Municipio { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Distrito")]
        public Int32 Distrito { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Unidad Vecinal")]
        public Int32 UnidadVecinal { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Dirección")]
        public String Direccion { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Coordenada")]
        public GeoCoordenada Coordenada { get; set; }
    }
    
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
        [Display(Name = "Dirección")]
        public String Direccion { get; set; }
        
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Coordenada")]
        public GeoCoordenada Coordenada { get; set; }
    }
}