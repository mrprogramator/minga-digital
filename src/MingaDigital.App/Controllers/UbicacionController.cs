using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("ubicaciones")]
    public class UbicacionController
        : BasicCrudController<
            MainContext,
            Ubicacion,
            UbicacionIndexModel,
            UbicacionIndexTableRow,
            UbicacionDetailModel,
            UbicacionEditorModel
        >
    {
        protected override IEnumerable<UbicacionIndexTableRow> GetIndexRows(UbicacionIndexModel model)
        {
            var query =
                CrudSet
                .Select(x => new UbicacionIndexTableRow
                {
                    UbicacionId = x.UbicacionId,
                    Municipio = x.Municipio.Nombre,
                    Distrito = x.Distrito,
                    UnidadVecinal = x.UnidadVecinal,
                    Direccion = x.Direccion
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override UbicacionDetailModel EntityToDetailModel(Ubicacion entity)
        {
            return new UbicacionDetailModel
            {
                UbicacionId = entity.UbicacionId,
                Municipio = entity.Municipio.Nombre,
                Distrito = entity.Distrito,
                UnidadVecinal = entity.UnidadVecinal,
                Direccion = entity.Direccion,
                Coordenada = entity.Coordenada
            };
        }
        
        protected override UbicacionEditorModel GetInitialEditorModel()
        {
            return new UbicacionEditorModel();
        }
        
        protected override UbicacionEditorModel EntityToEditorModel(Ubicacion entity)
        {
            return new UbicacionEditorModel
            {
                MunicipioId = entity.MunicipioId,
                Distrito = entity.Distrito,
                UnidadVecinal = entity.UnidadVecinal,
                Direccion = entity.Direccion,
                Coordenada = entity.Coordenada
            };
        }
        
        protected override Ubicacion EditorModelToEntity(UbicacionEditorModel model)
        {
            return new Ubicacion
            {
                MunicipioId = model.MunicipioId,
                Distrito = model.Distrito,
                UnidadVecinal = model.UnidadVecinal,
                Direccion = model.Direccion,
                Coordenada = model.Coordenada
            };
        }
        
        protected override void ApplyEditorModel(UbicacionEditorModel model, Ubicacion entity)
        {
            entity.MunicipioId = model.MunicipioId;
            entity.Distrito = model.Distrito;
            entity.UnidadVecinal = model.UnidadVecinal;
            entity.Direccion = model.Direccion;
            entity.Coordenada = model.Coordenada;
        }
    }
}
