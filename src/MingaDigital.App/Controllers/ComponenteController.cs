using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("componentes")]
    public class ComponenteController
        : BasicCrudController<
            MainContext,
            Componente,
            ComponenteIndexModel,
            ComponenteIndexTableRow,
            ComponenteDetailModel,
            ComponenteEditorModel
        >
    {
        protected override IEnumerable<ComponenteIndexTableRow> GetIndexRows(ComponenteIndexModel model)
        {
            var query =
                Db.Componente
                .Select(x => new ComponenteIndexTableRow
                {
                    ComponenteId = x.ComponenteId,
                    TipoComponente = x.TipoComponente.Nombre,
                    Marca = x.Marca,
                    Caracteristica = x.Caracteristica,
                    EquipoId = x.Equipo.EquipoId
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override ComponenteDetailModel EntityToDetailModel(Componente entity)
        {
            return new ComponenteDetailModel
            {
                ComponenteId = entity.ComponenteId,
                TipoComponente = entity.TipoComponente.Nombre,
                Marca = entity.Marca,
                Caracteristica = entity.Caracteristica,
                EquipoId = entity.Equipo.EquipoId
            };
        }
        
        protected override ComponenteEditorModel GetInitialEditorModel()
        {
            return new ComponenteEditorModel();
        }
        
        protected override ComponenteEditorModel EntityToEditorModel(Componente entity)
        {
            return new ComponenteEditorModel
            {
                TipoComponenteId = entity.TipoComponenteId,
                Marca = entity.Marca,
                Caracteristica =  entity.Caracteristica,
                EquipoId = entity.EquipoId
            };
        }
        
        protected override Componente EditorModelToEntity(ComponenteEditorModel model)
        {
            return new Componente
            {
                TipoComponenteId = model.TipoComponenteId,
                Marca = model.Marca,
                Caracteristica = model.Caracteristica,
                EquipoId = model.EquipoId
            };
        }
        
        protected override void ApplyEditorModel(ComponenteEditorModel model, Componente entity)
        {
            entity.TipoComponenteId = model.TipoComponenteId;
            entity.Marca = model.Marca;
            entity.Caracteristica = model.Caracteristica;
            entity.EquipoId = model.EquipoId;
        }
    }
}
