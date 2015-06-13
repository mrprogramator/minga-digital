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
                    ComponenteId = x.ActivoMingaId,
                    TipoComponente = x.TipoComponente.Nombre,
                    Marca = x.Marca,
                    Caracteristica = x.Caracteristica,
                    Establecimiento = x.Establecimiento.Nombre
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override ComponenteDetailModel EntityToDetailModel(Componente entity)
        {
            return new ComponenteDetailModel
            {
                ComponenteId = entity.ActivoMingaId,
                TipoComponente = entity.TipoComponente.Nombre,
                Marca = entity.Marca,
                Caracteristica = entity.Caracteristica,
                Establecimiento = entity.Establecimiento.Nombre
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
                EstablecimientoId =  entity.EstablecimientoId
            };
        }
        
        protected override Componente EditorModelToEntity(ComponenteEditorModel model)
        {
            var entity = new Componente();
            ApplyEditorModel(model, entity);
            return entity;
        }
        
        protected override void ApplyEditorModel(ComponenteEditorModel model, Componente entity)
        {
            entity.TipoComponenteId = model.TipoComponenteId;
            entity.Marca = model.Marca;
            entity.Caracteristica = model.Caracteristica;
            entity.EstablecimientoId =  model.EstablecimientoId;
        }
    }
}
