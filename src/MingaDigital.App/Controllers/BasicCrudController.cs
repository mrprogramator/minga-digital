using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

using Mappper = AutoMapper.Mapper;

namespace MingaDigital.App.Controllers
{
    public abstract class BasicCrudController<ContextT, EntityT, IndexModelT, EditorModelT> : Controller
        where ContextT : DbContext
        where EntityT : class
    {
        [FromServices]
        public ContextT Db { get; set; }
        
        protected DbSet<EntityT> CrudSet => Db.Set<EntityT>();
        
        protected abstract IndexModelT GetIndexModel(IQueryable<EntityT> source);
        
        protected abstract EntityT EditorModelToEntity(EditorModelT model);
        
        protected abstract EditorModelT EntityToEditorModel(EntityT entity);
        
        protected abstract void ApplyEditorModel(EditorModelT model, EntityT entity);
        
        [HttpGet("")]
        public virtual IActionResult Index()
        {
            var model = GetIndexModel(CrudSet);
            
            return View(model);
        }
        
        [HttpGet("nuevo")]
        public virtual IActionResult Create()
        {
            return View();
        }
        
        [HttpPost("nuevo")]
        public virtual IActionResult Create(EditorModelT model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var entity = EditorModelToEntity(model);
            
            CrudSet.Add(entity);
            Db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        
        [HttpGet("{id}/modificar")]
        public virtual IActionResult Update(Int32 id)
        {
            var entity = CrudSet.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            var model = EntityToEditorModel(entity);
            
            return View(model);
        }
        
        [HttpPost("{id}/modificar")]
        public virtual IActionResult Update(Int32 id, EditorModelT model)
        {
            var entity = CrudSet.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            ApplyEditorModel(model, entity);
            
            Db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        
        [HttpGet("{id}/eliminar")]
        public virtual IActionResult Delete(Int32 id)
        {
            var entity = CrudSet.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            return View(entity);
        }
        
         [HttpPost("{id}/eliminar")]
        public virtual IActionResult DeleteConfirm(Int32 id)
        {
            var entity = CrudSet.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            CrudSet.Remove(entity);
            Db.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
