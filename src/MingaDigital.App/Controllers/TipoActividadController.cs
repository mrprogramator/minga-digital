using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("tipos-actividad")]
    public class TipoActividadController
        : BasicCrudController<
            MainContext,
            TipoActividad,
            TipoActividadIndexModel,
            TipoActividadIndexTableRow,
            TipoActividadDetailModel,
            TipoActividadEditorModel
        >
    {
        protected override IEnumerable<TipoActividadIndexTableRow> GetIndexRows(TipoActividadIndexModel model)
        {
            var query =
                Db.TipoActividad
                .Select(x => new TipoActividadIndexTableRow
                {
                    TipoActividadId = x.TipoActividadId,
                    Descripcion = x.Descripcion
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override TipoActividadDetailModel EntityToDetailModel(TipoActividad entity)
        {
            return new TipoActividadDetailModel
            {
                TipoActividadId = entity.TipoActividadId,
                Descripcion = entity.Descripcion
            };
        }
        
        protected override TipoActividadEditorModel GetInitialEditorModel()
        {
            return new TipoActividadEditorModel();
        }
        
        protected override TipoActividadEditorModel EntityToEditorModel(TipoActividad entity)
        {
            return new TipoActividadEditorModel
            {
                Descripcion = entity.Descripcion
            };
        }
        
        protected override TipoActividad EditorModelToEntity(TipoActividadEditorModel model)
        {
            return new TipoActividad
            {
                Descripcion = model.Descripcion
            };
        }
        
        protected override void ApplyEditorModel(TipoActividadEditorModel model, TipoActividad entity)
        {
            entity.Descripcion = model.Descripcion;
        }
    }
}
