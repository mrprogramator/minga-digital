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
                CrudSet
                .Select(x => new PersonaJuridicaIndexTableRow
                {
                    PersonaId = x.PersonaId,
                    Nombre = x.Nombre
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override PersonaJuridicaDetailModel EntityToDetailModel(PersonaJuridica entity)
        {
            return new PersonaJuridicaDetailModel
            {
                PersonaId = entity.PersonaId,
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
