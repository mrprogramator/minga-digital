using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("almacen")]
    public class AlmacenController
        : BasicCrudController<
            MainContext,
            Almacen,
            AlmacenIndexModel,
            AlmacenIndexTableRow,
            AlmacenDetailModel,
            AlmacenEditorModel
        >
    {
        protected override IEnumerable<AlmacenIndexTableRow> GetIndexRows(AlmacenIndexModel model)
        {
            var query =
                Db.Almacen
                .Select(x => new AlmacenIndexTableRow
                {
                    EstablecimientoMingaId = x.EstablecimientoMingaId,
                    Nombre = x.Nombre,
                    Direccion = x.Ubicacion.Direccion 
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override AlmacenDetailModel EntityToDetailModel(Almacen entity)
        {
            return new AlmacenDetailModel
            {
                EstablecimientoMingaId = entity.EstablecimientoMingaId,
                Nombre = entity.Nombre,
                Direccion = entity.Ubicacion.Direccion
            };
        }
        
        protected override AlmacenEditorModel GetInitialEditorModel()
        {
            return new AlmacenEditorModel();
        }
        
        protected override AlmacenEditorModel EntityToEditorModel(Almacen entity)
        {
            return new AlmacenEditorModel
            {
                Nombre = entity.Nombre,
                UbicacionId = entity.UbicacionId
            };
        }
        
        protected override Almacen EditorModelToEntity(AlmacenEditorModel model)
        {
            return new Almacen
            {
                Nombre = model.Nombre,
                UbicacionId = model.UbicacionId
            };
        }
        
        protected override void ApplyEditorModel(AlmacenEditorModel model, Almacen entity)
        {
            entity.Nombre = model.Nombre;
            entity.UbicacionId = model.UbicacionId;
        }
    }
}
