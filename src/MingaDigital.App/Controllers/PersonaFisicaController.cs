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
    }
}
