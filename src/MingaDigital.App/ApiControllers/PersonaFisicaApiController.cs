using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.ApiModels;

namespace MingaDigital.App.ApiControllers
{
    [Route("api/persona-fisica")]
    public class PersonaFisicaApiController
    {
        [FromServices]
        public MainContext Db { get; set; }
        
        [HttpGet("name-search")]
        public IEnumerable<NameSearchApiModel<Int32>> NameSearch(String term)
        {
            var query =
                Db.PersonaFisica
                .Where(x =>
                    x.Nombres.ToLower().Contains(term.ToLower())
                    || x.Apellidos.ToLower().Contains(term.ToLower())
                )
                .Select(x => new NameSearchApiModel<Int32>
                {
                    Id = x.PersonaFisicaId,
                    Name = x.Nombres + " " + x.Apellidos
                });
            
            var result = query.ToArray();
            
            return result;
        }
    }
}