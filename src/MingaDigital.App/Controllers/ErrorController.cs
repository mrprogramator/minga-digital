using System;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

namespace MingaDigital.App.Controllers
{
    [AllowAnonymous]
    [Route("error")]
    public class ErrorController : Controller
    {
        // TODO algo mas elegante?
        private static readonly IDictionary<String, String> _errorMessages =
            new Dictionary<String, String>
            {
                ["db-conn"] = "No se pudo establecer la conexión a la base de datos."
            };
        
        [HttpGet("{errorName}")]
        public IActionResult DefaultError(String errorName)
        {
            Response.StatusCode = 500;
            
            String errorMessage = null;
            
            _errorMessages.TryGetValue(errorName, out errorMessage);
            
            ViewBag.ErrorMessage = errorMessage;
            
            return View();
        }
    }
}