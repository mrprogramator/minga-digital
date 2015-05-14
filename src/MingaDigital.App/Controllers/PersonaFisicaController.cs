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
    public class PersonaFisicaController : BasicCrudController<MainContext, PersonaFisica, PersonaFisicaIndexModel, PersonaEditorModel>
    {
        protected override PersonaFisicaIndexModel GetIndexModel(IQueryable<PersonaFisica> source)
        {
            var query =
                source;
            
            var result =
                query.ToArray()
                .Select(x => new PersonaFisicaIndexTableRow
                {
                    PersonaFisicaId = x.PersonaFisicaId,
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos
                });
            
            var model = new PersonaFisicaIndexModel
            {
                Table = new PersonaFisicaIndexTable { Rows = result }
            };
            
            return model;
        }
        
        protected override PersonaFisica EditorModelToEntity(PersonaEditorModel model)
        {
            return new PersonaFisica
            {
                Nombres = model.Nombres,
                Apellidos = model.Apellidos
            };
        }
        
        protected override PersonaEditorModel EntityToEditorModel(PersonaFisica entity)
        {
            return new PersonaEditorModel
            {
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos
            };
        }
        
        protected override void ApplyEditorModel(PersonaEditorModel model, PersonaFisica entity)
        {
            entity.Nombres = model.Nombres;
            entity.Apellidos = model.Apellidos;
        }
    }
}
