using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("configuracion/tipos-empresa")]
    public class TipoEmpresaController
        : BasicCrudController<
            MainContext,
            TipoEmpresa,
            TipoEmpresaIndexModel,
            TipoEmpresaIndexTableRow,
            TipoEmpresaDetailModel,
            TipoEmpresaEditorModel
        >
    {
        protected override IEnumerable<TipoEmpresaIndexTableRow> GetIndexRows(TipoEmpresaIndexModel model)
        {
            var query =
                Db.TipoEmpresa
                .Select(x => new TipoEmpresaIndexTableRow
                {
                    TipoEmpresaId = x.TipoEmpresaId,
                    Nombre = x.Nombre
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override TipoEmpresaDetailModel EntityToDetailModel(TipoEmpresa entity)
        {
            return new TipoEmpresaDetailModel
            {
                TipoEmpresaId = entity.TipoEmpresaId,
                Nombre = entity.Nombre
            };
        }
        
        protected override TipoEmpresaEditorModel GetInitialEditorModel()
        {
            return new TipoEmpresaEditorModel();
        }
        
        protected override TipoEmpresaEditorModel EntityToEditorModel(TipoEmpresa entity)
        {
            return new TipoEmpresaEditorModel
            {
                Nombre = entity.Nombre
            };
        }
        
        protected override TipoEmpresa EditorModelToEntity(TipoEmpresaEditorModel model)
        {
            return new TipoEmpresa
            {
                Nombre = model.Nombre
            };
        }
        
        protected override void ApplyEditorModel(TipoEmpresaEditorModel model, TipoEmpresa entity)
        {
            entity.Nombre = model.Nombre;
        }
    }
}