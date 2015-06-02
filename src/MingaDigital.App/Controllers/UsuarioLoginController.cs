using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;
using MingaDigital.App.Services;
using MingaDigital.Security;

namespace MingaDigital.App.Controllers
{
    public partial class UsuarioController : Controller
    {
        [FromServices]
        public UserSessionService UserSession { get; set; }
        
        [AllowAnonymous]
        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }
        
        [AllowAnonymous]
        [HttpPost("/login")]
        public IActionResult Login(UsuarioLoginModel model, String redirect)
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
            
            UserSession.StartUserSession(entity);
            
            return Redirect(redirect);
        }
        
        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            UserSession.EndUserSession();
            
            return Redirect("/");
        }
    }
}