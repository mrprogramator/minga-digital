using System;
using System.Linq;
//using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;

namespace MingaDigital.App.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [FromServices]
        public MainContext Db { get; set; }
        
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}