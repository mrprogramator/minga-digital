using System;
using System.Linq;
//using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("tipo_actividad")]
    public class TipoActividadController : Controller
    {
        [FromServices]
        public MainContext Db { get; set; }
        
        [HttpGet("")]
        public IActionResult Index()
        {
            var query =
                Db.Set<TipoActividad>()
                .OrderBy(x => x.Descripcion);
            
            var result = query.ToArray();
            
            return View(result);
        }

        [HttpGet("nuevo")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("nuevo")]
        public IActionResult Create([FromForm] TipoActividadCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var entity = new TipoActividad
            {
                Descripcion = model.Descripcion
            };
            
            Db.Set<TipoActividad>().Add(entity);
            
            Db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpGet("{id}/eliminar")]
        public IActionResult Delete(Int32 id)
        {
            return WithEntity(id, entity =>
            {
                return View(entity);
            });
        }

        [HttpGet("{id}/modificar")]
        public IActionResult Update(Int32 id)
        {
            return WithEntity(id, entity =>
            {
                var model = new TipoActividadCreateViewModel
                {
                    Descripcion = entity.Descripcion
                };
                return View("Create", model);
            });
        }

        [HttpPost("{id}/modificar")]
        public IActionResult Update(Int32 id, [FromForm] TipoActividadCreateViewModel model)
        {
            return WithEntity(id, entity =>
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", model);
                }

                entity.Descripcion = model.Descripcion;
                
                Db.SaveChanges();
                
                return RedirectToAction("Index");
            });
        }

        [HttpPost("{id}/eliminar")]
        public IActionResult DeleteConfirm(Int32 id)
        {
            return WithEntity(id, entity =>
            {
                Db.Set<TipoActividad>().Remove(entity);

                Db.SaveChanges();

                return RedirectToAction("Index");
            });
        }

        private IActionResult WithEntity(Int32 id, 
            Func<TipoActividad, IActionResult> func)
        {
            var query =
                Db.Set<TipoActividad>()
                .Where(p => p.Id == id);
            
            var result = query.FirstOrDefault();
            
            if (result == null)
            {
                return HttpNotFound();
            }
            
            return func.Invoke(result);
        }
    }
}