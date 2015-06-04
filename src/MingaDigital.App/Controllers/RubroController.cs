using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("configuracion/rubros")]
    public class RubroController
        : BasicCrudController<
            MainContext,
            Rubro,
            RubroIndexModel,
            RubroIndexTableRow,
            RubroDetailModel,
            RubroEditorModel
        >
    {
        protected override IEnumerable<RubroIndexTableRow> GetIndexRows(RubroIndexModel model)
        {
            var query =
                Db.Rubro
                .Select(x => new RubroIndexTableRow
                {
                    RubroId = x.RubroId,
                    Nombre = x.Nombre
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override RubroDetailModel EntityToDetailModel(Rubro entity)
        {
            return new RubroDetailModel
            {
                RubroId = entity.RubroId,
                Nombre = entity.Nombre
            };
        }
        
        protected override RubroEditorModel GetInitialEditorModel()
        {
            return new RubroEditorModel();
        }
        
        protected override RubroEditorModel EntityToEditorModel(Rubro entity)
        {
            return new RubroEditorModel
            {
                Nombre = entity.Nombre
            };
        }
        
        protected override Rubro EditorModelToEntity(RubroEditorModel model)
        {
            return new Rubro
            {
                Nombre = model.Nombre
            };
        }
        
        protected override void ApplyEditorModel(RubroEditorModel model, Rubro entity)
        {
            entity.Nombre = model.Nombre;
        }
    }
}
