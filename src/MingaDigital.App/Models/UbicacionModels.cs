using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MingaDigital.App.Entities;
using MingaDigital.App.ApiControllers;
using MingaDigital.App.Metadata;


namespace MingaDigital.App.Models
{
    [Description("Ubicaciones")]
    public class UbicacionIndexModel : BasicIndexModel<UbicacionIndexTableRow>
    {
    }
    
    public class UbicacionIndexTableRow
    {
        [Display(Name = "Codigo")]
        public Int32 UbicacionId { get; set; }
        
        [Display(Name = "Municipio")]
        public String Municipio { get; set; }
        
        [Display(Name = "Distrito")]
        public Int32 Distrito { get; set; }
        
        [Display(Name = "UV")]
        public Int32 UnidadVecinal { get; set; }
        
        [Display(Name = "Dirección")]
        public String Direccion { get; set; }
    }
    
    [Description("Ubicación")]
    public class UbicacionDetailModel
    {
        [Display(Name = "Codigo")]
        public Int32 UbicacionId { get; set; }
        
        [Display(Name = "Municipio")]
        public String Municipio { get; set; }
        
        [Display(Name = "Distrito")]
        public Int32 Distrito { get; set; }
        
        [Display(Name = "UV")]
        public Int32 UnidadVecinal { get; set; }
        
        [Display(Name = "Dirección")]
        public String Direccion { get; set; }
        
        [Display(Name = "Coordenada")]
        public GeoCoordenada Coordenada { get; set; }
    }
    
    [Description("Ubicación")]
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
    [AdditionalMetadata("Controller", "UbicacionApi")]
    [AdditionalMetadata("Action", nameof(UbicacionApiController.NameSearch))]
    public class UbicacionSelector : EntitySelector<Entities.Ubicacion, Int32>
    {
        public override String DisplayValue => 
            $"{Entity?.Direccion}, Municipio {Entity?.Municipio?.Nombre}"; 
        
        public static implicit operator UbicacionSelector(Entities.Ubicacion entity) =>
            new UbicacionSelector
            {
                Entity = entity,
                Key = entity.UbicacionId
            };
    }
}