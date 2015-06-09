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
                    Nombre = x.Nombre
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override TelecentroDetailModel EntityToDetailModel(Telecentro entity)
        {
            return new TelecentroDetailModel
            {
                EstablecimientoMingaId = entity.EstablecimientoMingaId,
                Nombre = entity.Nombre
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
                Nombre = entity.Nombre
            };
        }
        
        protected override Telecentro EditorModelToEntity(TelecentroEditorModel model)
        {
            return new Telecentro
            {
                Nombre = model.Nombre
            };
        }
        
        protected override void ApplyEditorModel(TelecentroEditorModel model, Telecentro entity)
        {
            entity.Nombre = model.Nombre;
        }
    }
}
