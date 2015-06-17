using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("municipios")]
    public class MunicipioController
        : BasicCrudController<
            MainContext,
            Municipio,
            MunicipioIndexModel,
            MunicipioIndexTableRow,
            MunicipioDetailModel,
            MunicipioEditorModel
        >
    {
        protected override IEnumerable<MunicipioIndexTableRow> GetIndexRows(MunicipioIndexModel model)
        {
            var query =
                Db.Municipio
                .Select(x => new MunicipioIndexTableRow
                {
                    MunicipioId = x.MunicipioId,
                    Nombre = x.Nombre 
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override MunicipioDetailModel EntityToDetailModel(Municipio entity)
        {
            return new MunicipioDetailModel
            {
                MunicipioId = entity.MunicipioId,
                Nombre = entity.Nombre
            };
        }
        
        protected override MunicipioEditorModel GetInitialEditorModel()
        {
            return new MunicipioEditorModel();
        }
        
        protected override MunicipioEditorModel EntityToEditorModel(Municipio entity)
        {
            return new MunicipioEditorModel
            {
                Nombre = entity.Nombre
            };
        }
        
        protected override Municipio EditorModelToEntity(MunicipioEditorModel model)
        {
            return new Municipio
            {
                Nombre = model.Nombre
            };
        }
        
        protected override void ApplyEditorModel(MunicipioEditorModel model, Municipio entity)
        {
            entity.Nombre = model.Nombre;
        }
    }
}
