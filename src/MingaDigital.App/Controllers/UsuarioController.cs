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
    [Route("usuarios")]
    public partial class UsuarioController : Controller
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
            
            return View(model);
        }

        private void LoadEntityData(Usuario entity, UsuarioChangePasswordModel model)
        {
            model.UsuarioId             = entity.UsuarioId;
            model.PersonaFisicaNombre   = entity.PersonaFisica.Nombre;
            model.Username              = entity.Username;
        }

        [HttpGet("{id}/reestablecer-password")]
        public IActionResult ChangePassword(Int32 id)
        {
            var entity =
                Db.Usuario
                .Include(x => x.PersonaFisica)
                .First(x => x.UsuarioId == id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            var model = new UsuarioChangePasswordModel();
            LoadEntityData(entity, model);
            
            return View(model);
        }
        
        [HttpPost("{id}/reestablecer-password")]
        public IActionResult ChangePassword(Int32 id, UsuarioChangePasswordModel model)
        {
            var entity =
                Db.Usuario
                .Include(x => x.PersonaFisica)
                .First(x => x.UsuarioId == id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            LoadEntityData(entity, model);
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var password = PasswordHash.Plain(model.Password);
            
            entity.Password = password;
            Db.SaveChanges();
            
            return RedirectToAction("Detail");
        }
    }
}