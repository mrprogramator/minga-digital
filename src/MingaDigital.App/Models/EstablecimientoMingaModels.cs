using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MingaDigital.App.ApiControllers;
using MingaDigital.App.Metadata;

namespace MingaDigital.App.Models
{
    
    [AdditionalMetadata("Controller", "EstablecimientoMingaApi")]
    [AdditionalMetadata("Action", nameof(EstablecimientoMingaApiController.NameSearch))]
    public class EstablecimientoMingaSelector : EntitySelector<Entities.EstablecimientoMinga, Int32>
    {
        public override String DisplayValue => Entity?.Nombre;
        
        public static implicit operator EstablecimientoMingaSelector(Entities.EstablecimientoMinga entity) =>
            new EstablecimientoMingaSelector
            {
                Entity = entity,
                Key = entity.EstablecimientoMingaId
            };
    }
}