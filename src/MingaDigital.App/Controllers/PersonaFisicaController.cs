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
                    PersonaFisicaId = x.PersonaFisicaId,
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos,
                    Nit = x.Nit
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override PersonaFisicaDetailModel EntityToDetailModel(PersonaFisica entity)
        {
            return new PersonaFisicaDetailModel
            {
                PersonaFisicaId = entity.PersonaFisicaId,
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos,
                Nit = entity.Nit,
                Direccion = entity.Direccion
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
                Apellidos = entity.Apellidos,
                Nit = entity.Nit,
                Direccion = entity.Direccion
            };
        }
        
        protected override PersonaFisica EditorModelToEntity(PersonaFisicaEditorModel model)
        {
            return new PersonaFisica
            {
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                Nit = model.Nit,
                Direccion = model.Direccion
            };
        }
        
        protected override void ApplyEditorModel(PersonaFisicaEditorModel model, PersonaFisica entity)
        {
            entity.Nombres = model.Nombres;
            entity.Apellidos = model.Apellidos;
            entity.Nit = model.Nit;
            entity.Direccion = model.Direccion;
        }
    }
}
