using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    public abstract class BasicCrudController<ContextT, EntityT, IndexModelT, IndexRowT, DetailModelT, EditorModelT> : Controller
        where ContextT : DbContext
        where EntityT : class
        where IndexModelT : BasicIndexModel<IndexRowT>
    {
        [FromServices]
        public ContextT Db { get; set; }
        
        protected abstract IEnumerable<IndexRowT> GetIndexRows(IndexModelT model);
        
        protected abstract DetailModelT EntityToDetailModel(EntityT entity);
        
        protected abstract EditorModelT GetInitialEditorModel();
        
        protected abstract EditorModelT EntityToEditorModel(EntityT entity);
        
        protected abstract EntityT EditorModelToEntity(EditorModelT model);
        
        protected abstract void ApplyEditorModel(EditorModelT model, EntityT entity);
        
        private DbSet<EntityT> CrudSet => Db.Set<EntityT>();
        
        [HttpGet("")]
        public virtual IActionResult Index(IndexModelT model)
        {
            var rows = GetIndexRows(model);
            
            model.Table = new BasicTable<IndexRowT>
            {
                Rows = rows
            };
            
            return View(model);
        }
        
        [HttpGet("{id}")]
        public virtual IActionResult Detail(Int32 id)
        {
            var entity = CrudSet.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            var model = EntityToDetailModel(entity);
            
            return View(model);
        }
        
        [HttpGet("nuevo")]
        public virtual IActionResult Create()
        {
            var model = GetInitialEditorModel();
            
            return View(model);
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
            
            var model = EntityToDetailModel(entity);
            
            return View(model);
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
