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
    public class PersonaFisicaController : Controller
    {
        [FromServices]
        public MainContext Db { get; set; }
        
        [HttpGet("")]
        public IActionResult Index()
        {
            var query =
                Db.PersonaFisica
                .Select(x => new { x.PersonaFisicaId, x.Nombres, x.Apellidos });
            
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
            
            return View(model);
        }
        
        [HttpGet("nuevo")]
        public IActionResult Create()
        {
            return View("Editor");
        }
        
        [HttpPost("nuevo")]
        public IActionResult Create(PersonaEditorModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Editor", model);
            }
            
            var entity = new PersonaFisica
            {
                Nombres = model.Nombres,
                Apellidos = model.Apellidos
            };
            
            Db.PersonaFisica.Add(entity);
            Db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        
        [HttpGet("{id}/modificar")]
        public IActionResult Update(Int32 id)
        {
            var entity = Db.PersonaFisica.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            var model = new PersonaEditorModel
            {
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos
            };
            
            return View("Editor", model);
        }
        
        [HttpPost("{id}/modificar")]
        public IActionResult Update(Int32 id, PersonaEditorModel model)
        {
            var entity = Db.PersonaFisica.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            if (!ModelState.IsValid)
            {
                return View("Editor", model);
            }
            
            entity.Nombres = model.Nombres;
            entity.Apellidos = model.Apellidos;
            
            Db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        
        [HttpGet("{id}/eliminar")]
        public IActionResult Delete(Int32 id)
        {
            var entity = Db.PersonaFisica.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            return View(entity);
        }
        
         [HttpPost("{id}/eliminar")]
        public IActionResult DeleteConfirm(Int32 id)
        {
            var entity = Db.PersonaFisica.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            Db.PersonaFisica.Remove(entity);
            Db.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
