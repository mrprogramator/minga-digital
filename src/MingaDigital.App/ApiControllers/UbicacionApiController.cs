using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.ApiModels;

namespace MingaDigital.App.ApiControllers
{
    [Route("api/ubicacion")]
    public class UbicacionApiController
    {
        [FromServices]
        public MainContext Db { get; set; }
        
        [HttpGet("name-search")]
        public IEnumerable<NameSearchApiModel<Int32>> NameSearch(String term)
        {
            var query =
                Db.Ubicacion
                .Select(x => new NameSearchApiModel<Int32>
                {
                    Key = x.UbicacionId,
                    Value = x.Direccion + ", Municipio " + x.Municipio.Nombre
                })
                .Where(x => x.Value.ToLower().Contains(term.ToLower()));
            
            var result = query.ToArray();
            
            return result;
        }
    }
}