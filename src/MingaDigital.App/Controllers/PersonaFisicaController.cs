using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;
using MingaDigital.Security;

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
                Db.PersonaFisica
                .Select(x => new PersonaFisicaIndexTableRow
                {
                    PersonaFisicaId = x.PersonaFisicaId,
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos,
                    Nit = x.Nit,
                    UsuarioId = x.Usuario.UsuarioId
                });
            
            var result = query.ToArray();
            
            return result;
        }
        
        protected override PersonaFisica GetDetailEntity(Int32 id) =>
            Db.PersonaFisica
            .Include(x => x.Usuario)
            .FirstOrDefault(x => x.PersonaFisicaId == id);
        
        protected override PersonaFisicaDetailModel EntityToDetailModel(PersonaFisica entity)
        {
            return new PersonaFisicaDetailModel
            {
                PersonaFisicaId = entity.PersonaFisicaId,
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos,
                Nit = entity.Nit,
                Direccion = entity.Direccion,
                UsuarioId = entity.Usuario?.UsuarioId
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
        
        protected override void LoadStaticData(Int32 id, PersonaFisica entity, PersonaFisicaEditorModel model)
        {
            model.PersonaFisicaId = entity.PersonaFisicaId;
        }
        
        protected override void ApplyEditorModel(PersonaFisicaEditorModel model, PersonaFisica entity)
        {
            entity.Nombres = model.Nombres;
            entity.Apellidos = model.Apellidos;
            entity.Nit = model.Nit;
            entity.Direccion = model.Direccion;
        }
        
        protected override IActionResult ResultAfterWrite(PersonaFisica entity)
        {
            return RedirectToAction("Detail", new { id = entity.PersonaFisicaId });
        }
        
        private void LoadEntityData(PersonaFisica entity, UsuarioEditorModel model)
        {
            model.PersonaFisicaId = entity.PersonaFisicaId;
            model.PersonaFisicaNombre = entity.Nombre;
        }
        
        [HttpGet("{id}/crear-usuario")]
        public IActionResult CreateUser(Int32 id)
        {
            var entity = Db.PersonaFisica.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            var model = new UsuarioEditorModel();
            LoadEntityData(entity, model);
            
            return View(model);
        }
        
        [HttpPost("{id}/crear-usuario")]
        public IActionResult CreateUser(Int32 id, UsuarioEditorModel model)
        {
            var entity = Db.PersonaFisica.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            LoadEntityData(entity, model);
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var password = PasswordHash.Plain(model.Password);
            
            var usuario = new Usuario
            {
                PersonaFisica = entity,
                Username = model.Username,
                Password = password
            };
            
            Db.Usuario.Add(usuario);
            Db.SaveChanges();
            
            return ResultAfterWrite(entity);
        }
    }
}
