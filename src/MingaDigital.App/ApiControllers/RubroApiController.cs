using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.ApiModels;

namespace MingaDigital.App.ApiControllers
{
    [Route("api/rubro")]
    public class RubroApiController
    {
        [FromServices]
        public MainContext Db { get; set; }
        
        [HttpGet("name-search")]
        public IEnumerable<NameSearchApiModel<Int32>> NameSearch(String term)
        {
            var query =
                Db.Rubro
                .Where(x => x.Nombre.ToLower().Contains(term.ToLower()))
                .Select(x => new NameSearchApiModel<Int32>
                {
                    Key = x.RubroId,
                    Value = x.Nombre
                });
            
            var result = query.ToArray();
            
            return result;
        }
    }
}