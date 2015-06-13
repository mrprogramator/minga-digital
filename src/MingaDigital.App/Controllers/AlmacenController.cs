using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("almacenes")]
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
                    Ubicacion = x.Ubicacion.Direccion + ", Distrito " + x.Ubicacion.Distrito 
                        + ", Muncipio " + x.Ubicacion.Municipio.Nombre 
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
                Ubicacion = entity.Ubicacion.Direccion + ", Distrito " + entity.Ubicacion.Distrito 
                        + ", Muncipio " + entity.Ubicacion.Municipio.Nombre
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
            var entity = new Almacen();
            ApplyEditorModel(model, entity);
            return entity;
        }
        
        protected override void ApplyEditorModel(AlmacenEditorModel model, Almacen entity)
        {
            entity.Nombre = model.Nombre;
            entity.UbicacionId = model.UbicacionId;
        }
    }
}
