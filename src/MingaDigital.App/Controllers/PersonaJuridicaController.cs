using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("personas-juridicas")]
    public class PersonaJuridicaController
        : BasicCrudController<
            MainContext,
            PersonaJuridica,
            PersonaJuridicaIndexModel,
            PersonaJuridicaIndexTableRow,
            PersonaJuridicaDetailModel,
            PersonaJuridicaEditorModel
        >
    {
        protected override IEnumerable<PersonaJuridicaIndexTableRow> GetIndexRows(PersonaJuridicaIndexModel model)
        {
            var query =
                Db.PersonaJuridica
                .OrderBy(x => x.Nombre)
                .Select(x => new PersonaJuridicaIndexTableRow
                {
                    PersonaJuridicaId = x.PersonaJuridicaId,
                    Nombre = x.Nombre
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override PersonaJuridicaDetailModel EntityToDetailModel(PersonaJuridica entity)
        {
            return new PersonaJuridicaDetailModel
            {
                PersonaJuridicaId = entity.PersonaJuridicaId,
                Nombre = entity.Nombre
            };
        }
        
        protected override PersonaJuridicaEditorModel GetInitialEditorModel()
        {
            return new PersonaJuridicaEditorModel();
        }
        
        protected override PersonaJuridicaEditorModel EntityToEditorModel(PersonaJuridica entity)
        {
            return new PersonaJuridicaEditorModel
            {
                Nombre = entity.Nombre,
                Nit = entity.Nit,
                Direccion = entity.Direccion,
                // TODO prefetch foreign entities:
                Rubro = entity.Rubro,
                TipoEmpresa = entity.TipoEmpresa,
                Encargado = entity.Encargado
            };
        }
        
        protected override PersonaJuridica EditorModelToEntity(PersonaJuridicaEditorModel model)
        {
            var entity = new PersonaJuridica();
            ApplyEditorModel(model, entity);
            return entity;
        }
        
        protected override void ApplyEditorModel(PersonaJuridicaEditorModel model, PersonaJuridica entity)
        {
            entity.Nombre = model.Nombre;
            entity.Nit = model.Nit;
            entity.Direccion = model.Direccion;
            entity.Rubro = model.Rubro;
            entity.TipoEmpresa = model.TipoEmpresa;
            entity.Encargado = model.Encargado;
        }
    }
}
