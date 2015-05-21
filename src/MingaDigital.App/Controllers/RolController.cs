using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("roles")]
    public class RolController
        : BasicCrudController<
            MainContext,
            Rol,
            RolIndexModel,
            RolIndexTableRow,
            RolDetailModel,
            RolEditorModel
        >
    {
        protected override IEnumerable<RolIndexTableRow> GetIndexRows(RolIndexModel model)
        {
            var query =
                CrudSet
                .Select(x => new RolIndexTableRow
                {
                    RolId = x.RolId,
                    Nombre = x.Nombre
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override RolDetailModel EntityToDetailModel(Rol entity)
        {
            return new RolDetailModel
            {
                RolId = entity.RolId,
                Nombre = entity.Nombre
            };
        }
        
        protected override RolEditorModel GetInitialEditorModel()
        {
            return new RolEditorModel();
        }
        
        protected override RolEditorModel EntityToEditorModel(Rol entity)
        {
            return new RolEditorModel
            {
                Nombre = entity.Nombre
            };
        }
        
        protected override Rol EditorModelToEntity(RolEditorModel model)
        {
            return new Rol
            {
                Nombre = model.Nombre
            };
        }
        
        protected override void ApplyEditorModel(RolEditorModel model, Rol entity)
        {
            entity.Nombre = model.Nombre;
        }
    }
}
