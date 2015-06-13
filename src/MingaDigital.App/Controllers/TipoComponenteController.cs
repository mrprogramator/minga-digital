using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("tipos-componente")]
    public class TipoComponenteController
        : BasicCrudController<
            MainContext,
            TipoComponente,
            TipoComponenteIndexModel,
            TipoComponenteIndexTableRow,
            TipoComponenteDetailModel,
            TipoComponenteEditorModel
        >
    {
        protected override IEnumerable<TipoComponenteIndexTableRow> GetIndexRows(TipoComponenteIndexModel model)
        {
            var query =
                Db.TipoComponente
                .Select(x => new TipoComponenteIndexTableRow
                {
                    TipoComponenteId = x.TipoComponenteId,
                    Nombre = x.Nombre 
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override TipoComponenteDetailModel EntityToDetailModel(TipoComponente entity)
        {
            return new TipoComponenteDetailModel
            {
                TipoComponenteId = entity.TipoComponenteId,
                Nombre = entity.Nombre
            };
        }
        
        protected override TipoComponenteEditorModel GetInitialEditorModel()
        {
            return new TipoComponenteEditorModel();
        }
        
        protected override TipoComponenteEditorModel EntityToEditorModel(TipoComponente entity)
        {
            return new TipoComponenteEditorModel
            {
                Nombre = entity.Nombre
            };
        }
        
        protected override TipoComponente EditorModelToEntity(TipoComponenteEditorModel model)
        {
            return new TipoComponente
            {
                Nombre = model.Nombre
            };
        }
        
        protected override void ApplyEditorModel(TipoComponenteEditorModel model, TipoComponente entity)
        {
            entity.Nombre = model.Nombre;
        }
    }
}
