using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("usuarios")]
    public class UsuarioController : Controller
    {
        [FromServices]
        public MainContext Db { get; set; }
        
        [HttpGet("{id}")]
        public IActionResult Detail(Int32 id)
        {
            var entity =
                Db.Usuario
                .Include(x => x.PersonaFisica)
                .First(x => x.UsuarioId == id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            var model = new UsuarioDetailModel
            {
                PersonaFisicaId = entity.PersonaFisica.PersonaFisicaId,
                PersonaFisicaNombre = entity.PersonaFisica.Nombre,
                Username = entity.Username
            };
            
            return View("Detail", model);
        }
    }
}