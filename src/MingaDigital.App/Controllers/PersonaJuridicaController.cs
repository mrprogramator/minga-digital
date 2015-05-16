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
            PersonaJuridicaDetailModel,
            PersonaJuridicaEditorModel
        >
    {
        protected override PersonaJuridicaIndexModel GetIndexModel()
        {
            var query =
                CrudSet;
            
            var result =
                query.ToArray()
                .Select(x => new PersonaJuridicaIndexTableRow
                {
                    PersonaJuridicaId = x.PersonaJuridicaId,
                    Nombre = x.Nombre
                });
            
            var model = new PersonaJuridicaIndexModel
            {
                Table = new PersonaJuridicaIndexTable { Rows = result }
            };
            
            return model;
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
                Nombre = entity.Nombre
            };
        }
        
        protected override PersonaJuridica EditorModelToEntity(PersonaJuridicaEditorModel model)
        {
            return new PersonaJuridica
            {
                Nombre = model.Nombre
            };
        }
        
        protected override void ApplyEditorModel(PersonaJuridicaEditorModel model, PersonaJuridica entity)
        {
            entity.Nombre = model.Nombre;
        }
    }
}
