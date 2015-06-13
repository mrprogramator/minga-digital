using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("telecentros")]
    public class TelecentroController
        : BasicCrudController<
            MainContext,
            Telecentro,
            TelecentroIndexModel,
            TelecentroIndexTableRow,
            TelecentroDetailModel,
            TelecentroEditorModel
        >
    {
        protected override IEnumerable<TelecentroIndexTableRow> GetIndexRows(TelecentroIndexModel model)
        {
            var query =
                Db.Telecentro
                .Select(x => new TelecentroIndexTableRow
                {
                    EstablecimientoMingaId = x.EstablecimientoMingaId,
                    Nombre = x.Nombre,
                    Patrocinador = x.Patrocinador.Nombre,
                    ProveedorInternet = x.ProveedorInternet.Nombre,
                    Ubicacion = x.Ubicacion.Direccion + ", Distrito " + x.Ubicacion.Distrito 
                        + ", Muncipio " + x.Ubicacion.Municipio.Nombre
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override TelecentroDetailModel EntityToDetailModel(Telecentro entity)
        {
            return new TelecentroDetailModel
            {
                EstablecimientoMingaId = entity.EstablecimientoMingaId,
                Nombre = entity.Nombre,
                Patrocinador = entity.Patrocinador.Nombre,
                ProveedorInternet = entity.ProveedorInternet.Nombre,
                Ubicacion = entity.Ubicacion.Direccion + ", Distrito " + entity.Ubicacion.Distrito 
                        + ", Muncipio " + entity.Ubicacion.Municipio.Nombre
            };
        }
        
        protected override TelecentroEditorModel GetInitialEditorModel()
        {
            return new TelecentroEditorModel();
        }
        
        protected override TelecentroEditorModel EntityToEditorModel(Telecentro entity)
        {
            return new TelecentroEditorModel
            {
                Nombre = entity.Nombre,
                PatrocinadorId = entity.PatrocinadorId,
                ProveedorInternetId =  entity.ProveedorInternetId,
                UbicacionId = entity.UbicacionId
            };
        }
        
        protected override Telecentro EditorModelToEntity(TelecentroEditorModel model)
        {
            var entity = new Telecentro();
            ApplyEditorModel(model, entity);
            return entity;
        }
        
        protected override void ApplyEditorModel(TelecentroEditorModel model, Telecentro entity)
        {
            entity.Nombre = model.Nombre;
            entity.PatrocinadorId = model.PatrocinadorId;
            entity.ProveedorInternetId = model.ProveedorInternetId;
            entity.UbicacionId = model.UbicacionId;
        }
    }
}
