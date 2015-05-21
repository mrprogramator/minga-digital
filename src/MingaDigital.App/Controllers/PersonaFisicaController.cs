using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("personas-fisicas")]
    public class PersonaFisicaController
        : BasicCrudController<
            MainContext,
            PersonaFisica,
            PersonaFisicaIndexModel,
            PersonaFisicaIndexTableRow,
            PersonaFisicaDetailModel,
            PersonaFisicaEditorModel
        >
    {
        protected override IEnumerable<PersonaFisicaIndexTableRow> GetIndexRows(PersonaFisicaIndexModel model)
        {
            var query =
                CrudSet
                .Select(x => new PersonaFisicaIndexTableRow
                {
                    PersonaId = x.PersonaId,
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override PersonaFisicaDetailModel EntityToDetailModel(PersonaFisica entity)
        {
            return new PersonaFisicaDetailModel
            {
                PersonaId = entity.PersonaId,
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos
            };
        }
        
        protected override PersonaFisicaEditorModel GetInitialEditorModel()
        {
            return new PersonaFisicaEditorModel();
        }
        
        protected override PersonaFisicaEditorModel EntityToEditorModel(PersonaFisica entity)
        {
            return new PersonaFisicaEditorModel
            {
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos
            };
        }
        
        protected override PersonaFisica EditorModelToEntity(PersonaFisicaEditorModel model)
        {
            return new PersonaFisica
            {
                Nombres = model.Nombres,
                Apellidos = model.Apellidos
            };
        }
        
        protected override void ApplyEditorModel(PersonaFisicaEditorModel model, PersonaFisica entity)
        {
            entity.Nombres = model.Nombres;
            entity.Apellidos = model.Apellidos;
        }
    }
}
