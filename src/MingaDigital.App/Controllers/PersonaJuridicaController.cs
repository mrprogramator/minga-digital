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
            var model = new PersonaJuridicaEditorModel
            {
                Nombre = entity.Nombre,
                Nit = entity.Nit,
                Direccion = entity.Direccion
            };
            
            model.Rubro.Key = entity.RubroId;
            model.Rubro.Value = entity.Rubro.Nombre;
            model.TipoEmpresa.Key = entity.TipoEmpresaId;
            model.TipoEmpresa.Value = entity.TipoEmpresa.Nombre;
            model.Encargado.Key = entity.EncargadoId;
            model.Encargado.Value = entity.Encargado.Nombre;
            
            return model;
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
            entity.RubroId = model.Rubro.Key;
            entity.TipoEmpresaId = model.TipoEmpresa.Key;
            entity.EncargadoId = model.Encargado.Key;
        }
    }
}
