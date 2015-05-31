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
    public partial class UsuarioController : Controller
    {
        [AllowAnonymous]
        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }
        
        [AllowAnonymous]
        [HttpPost("/login")]
        public IActionResult Login(UsuarioLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var entity = Db.Usuario.FirstOrDefault(u => u.Username == model.Username);
            
            if (entity == null)
            {
                // TODO mover cadena de error
                ModelState.AddModelError("Username", "El usuario no existe.");
                return View(model);
            }
            
            var password = PasswordHash.Plain(model.Password);
            
            if (!password.Equals(entity.Password))
            {
                // TODO mover cadena de error
                ModelState.AddModelError("Password", "Password incorrecto.");
                return View(model);
            }
            
            // TODO factorizar logica de sesion
            var sesion = new SesionUsuario
            {
                Id = Guid.NewGuid().ToString(),
                Usuario = entity,
                FechaHoraCreacion = DateTimeOffset.UtcNow,
                FechaHoraExpiracion = DateTimeOffset.UtcNow.AddMinutes(5)
            };
            
            Db.SesionUsuario.Add(sesion);
            Db.SaveChanges();
            
            // TODO mover nombre de cookie
            Response.Cookies.Append("session_token", sesion.Id);
            
            return Redirect("/");
        }
    }
}