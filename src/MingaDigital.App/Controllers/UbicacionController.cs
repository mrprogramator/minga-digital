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
    [Route("ubicaciones")]
    public class UbicacionController : Controller
    {
        [FromServices]
        public MainContext Db { get; set; }
        
        [HttpGet("")]
        public IActionResult Index()
        {
            var query =
                Db.Ubicacion
                .OrderBy(x => x.MunicipioId);
            
            var result = query.ToArray();
            
            return View(result);
        }
        
        [HttpGet("nuevo")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost("nuevo")]
        public IActionResult Create(UbicacionEditorModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var entity = new Ubicacion
            {
                MunicipioId = model.MunicipioId,
                Distrito = model.Distrito,
                UnidadVecinal = model.UnidadVecinal,
                Direccion = model.Direccion,
                Coordenada = model.Coordenada
            };
            
            Db.Ubicacion.Add(entity);
            Db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        
        [HttpGet("{id}/modificar")]
        public IActionResult Update(Int32 id)
        {
            var entity = Db.Ubicacion.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            var model = new UbicacionEditorModel
            {
                MunicipioId = entity.MunicipioId,
                Distrito = entity.Distrito,
                UnidadVecinal = entity.UnidadVecinal,
                Direccion = entity.Direccion,
                Coordenada = entity.Coordenada
            };
            
            return View("Create", model);
        }
        
        [HttpPost("{id}/modificar")]
        public IActionResult Update(Int32 id, UbicacionEditorModel model)
        {
            var entity = Db.Ubicacion.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }
            
            entity.MunicipioId = model.MunicipioId;
            entity.Distrito = model.Distrito;
            entity.UnidadVecinal = model.UnidadVecinal;
            entity.Direccion = model.Direccion;
            entity.Coordenada = model.Coordenada;
            
            Db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        
        [HttpGet("{id}/eliminar")]
        public IActionResult Delete(Int32 id)
        {
            var entity = Db.Ubicacion.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            Db.Ubicacion.Remove(entity);
            Db.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
