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
            PersonaFisicaDetailModel,
            PersonaFisicaEditorModel
        >
    {
        protected override PersonaFisicaIndexModel GetIndexModel()
        {
            var query =
                CrudSet;
            
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
        
        protected override PersonaFisicaDetailModel EntityToDetailModel(PersonaFisica entity)
        {
            return new PersonaFisicaDetailModel
            {
                PersonaFisicaId = entity.PersonaFisicaId,
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
