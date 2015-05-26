using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("tipos-incidencia")]
    public class TipoIncidenciaController
        : BasicCrudController<
            MainContext,
            TipoIncidencia,
            TipoIncidenciaIndexModel,
            TipoIncidenciaIndexTableRow,
            TipoIncidenciaDetailModel,
            TipoIncidenciaEditorModel
        >
    {
        protected override IEnumerable<TipoIncidenciaIndexTableRow> GetIndexRows(TipoIncidenciaIndexModel model)
        {
            var query =
                CrudSet
                .Select(x => new TipoIncidenciaIndexTableRow
                {
                    TipoIncidenciaId = x.TipoIncidenciaId,
                    Nombre = x.Nombre
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override TipoIncidenciaDetailModel EntityToDetailModel(TipoIncidencia entity)
        {
            return new TipoIncidenciaDetailModel
            {
                TipoIncidenciaId = entity.TipoIncidenciaId,
                Nombre = entity.Nombre
            };
        }
        
        protected override TipoIncidenciaEditorModel GetInitialEditorModel()
        {
            return new TipoIncidenciaEditorModel();
        }
        
        protected override TipoIncidenciaEditorModel EntityToEditorModel(TipoIncidencia entity)
        {
            return new TipoIncidenciaEditorModel
            {
                Nombre = entity.Nombre
            };
        }
        
        protected override TipoIncidencia EditorModelToEntity(TipoIncidenciaEditorModel model)
        {
            return new TipoIncidencia
            {
                Nombre = model.Nombre
            };
        }
        
        protected override void ApplyEditorModel(TipoIncidenciaEditorModel model, TipoIncidencia entity)
        {
            entity.Nombre = model.Nombre;
        }
    }
}
