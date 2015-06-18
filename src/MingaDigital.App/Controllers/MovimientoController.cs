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
    [Route("movimientos")]
    public class MovimientoController : Controller
    {
        [FromServices]
        public MainContext Db { get; set; }
        
        [HttpGet("nuevo/uno")]
        public IActionResult CreateStepOne()
        {
            var model = new MovimientoCreateStepOneModel
            {
                
            };
            
            return View(model);
        }
        
        [HttpPost("nuevo/uno")]
        public IActionResult CreateStepOne(MovimientoCreateStepOneModel model)
        {
            if (ModelState.IsValid && model.Origen?.Key == model.Destino?.Key)
            {
                ModelState.AddModelError("","Origen y Destino no pueden ser iguales.");
            }
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var actionParams = new
            {
                origenId = model.Origen.Key,
                destinoId = model.Destino.Key
            };
            return RedirectToAction(nameof(CreateStepTwo), actionParams);
        }
        
        [HttpGet("nuevo/dos")]
        public IActionResult CreateStepTwo(Int32 origenId, Int32 destinoId)
        {
            var origen = Db.EstablecimientoMinga.Find(origenId);
            var destino = Db.EstablecimientoMinga.Find(destinoId);
            if (origen == null || destino == null)
            {
                ViewBag.ErrorMessage = "Origen o Destino invalidos.";
                return View("CreateStepTwoError");
            }
            var componentes = 
                Db.Componente
                .Where(x => x.EstablecimientoId == origenId)
                .OrderBy(x => x.TipoComponente.Nombre)
                .ToArray();
            
            var model = new MovimientoCreateStepTwoModel
            {
                OrigenNombre = origen.Nombre,
                DestinoNombre = destino.Nombre
            };
            return View(model);
        }
        [HttpPost("nuevo/dos")]
        public IActionResult CreateStepTwo(Int32 origenId, Int32 destinoId, MovimientoCreateStepTwoModel model)
        {
            var origen = Db.EstablecimientoMinga.Find(origenId);
            var destino = Db.EstablecimientoMinga.Find(destinoId);
            if (origen == null || destino == null)
            {
                ViewBag.ErrorMessage = "Origen o Destino invalidos.";
                return View("CreateStepTwoError");
            }
            model.OrigenNombre = origen.Nombre;
            model.DestinoNombre = destino.Nombre;
            
            var componentes = 
                Db.Componente
                .Where(x => x.EstablecimientoId == origenId)
                .OrderBy(x => x.TipoComponente.Nombre)
                .ToArray();
            
            return View(model);
        }
    }
}