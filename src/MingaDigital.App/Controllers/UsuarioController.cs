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
                .FirstOrDefault(x => x.UsuarioId == id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            var roles =
                Db.UsuarioRol
                .Where(x => x.UsuarioId == id)
                .Select(x => x.Rol)
                .Select(x => new UsuarioRolDetailModel
                {
                    RolId = x.RolId,
                    Nombre = x.Nombre
                })
                .OrderBy(x => x.Nombre)
                .ToArray();
            
            var model = new UsuarioDetailModel
            {
                UsuarioId = entity.UsuarioId,
                PersonaFisicaId = entity.PersonaFisica.PersonaFisicaId,
                PersonaFisicaNombre = entity.PersonaFisica.Nombre,
                Username = entity.Username,
                Roles = roles
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
                .FirstOrDefault(x => x.UsuarioId == id);
            
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
                .FirstOrDefault(x => x.UsuarioId == id);
            
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
            
            return RedirectToAction("Detail", new { id = id });
        }
        
        [HttpGet("{id}/gestionar-roles")]
        public IActionResult ManageRoles(Int32 id)
        {
            var entity =
                Db.Usuario
                .FirstOrDefault(x => x.UsuarioId == id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            var roles =
                Db.Rol
                .Select(x => new UsuarioRolAssignModel
                {
                    RolId = x.RolId,
                    Nombre = x.Nombre,
                    Assigned =
                        Db.UsuarioRol
                        .Where(y => y.UsuarioId == id)
                        .Any(y => x.RolId == y.RolId)
                })
                .OrderBy(x => x.Nombre)
                .ToArray();
            
            var model = new UsuarioManageRolesModel
            {
                UsuarioId = id,
                Roles = roles
            };
            
            return View(model);
        }
        
        [HttpPost("{id}/gestionar-roles")]
        public IActionResult ManageRoles(Int32 id, UsuarioManageRolesModel model)
        {
            var entity =
                Db.Usuario
                .FirstOrDefault(x => x.UsuarioId == id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ManageRoles");
            }
            
            var inputRolIds = model.Roles.Select(x => x.RolId).ToArray();
            
            var existingRolIdsCount =
                Db.Rol
                .Where(x => inputRolIds.Contains(x.RolId))
                .Count();
            
            if (inputRolIds.Length != existingRolIdsCount)
            {
                return RedirectToAction("ManageRoles");
            }
            
            var usuarioRoles =
                Db.UsuarioRol
                .Where(x => x.UsuarioId == id)
                .ToArray()
                .ToDictionary(x => x.RolId, x => x);
            
            var remove = new List<UsuarioRol>();
            var create = new List<UsuarioRol>();
            
            foreach (var assignment in model.Roles)
            {
                UsuarioRol existing = null;
                
                usuarioRoles.TryGetValue(assignment.RolId, out existing);
                
                if (assignment.Assigned && existing == null)
                {
                    create.Add(new UsuarioRol
                    {
                        RolId = assignment.RolId,
                        UsuarioId = id
                    });
                }
                else if (!assignment.Assigned && existing != null)
                {
                    remove.Add(existing);
                }
                else
                {
                    // don't care
                }
            }
            
            Db.UsuarioRol.RemoveRange(remove);
            Db.UsuarioRol.AddRange(create);
            Db.SaveChanges();
            
            return RedirectToAction("Detail", new { id = id });
        }
        
        [HttpGet("{id}/eliminar")]
        public virtual IActionResult Delete(Int32 id)
        {
            var entity = Db.Usuario.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            var model = new UsuarioDetailModel
            {
                UsuarioId = entity.UsuarioId,
                PersonaFisicaId = entity.PersonaFisica.PersonaFisicaId,
                PersonaFisicaNombre = entity.PersonaFisica.Nombre,
                Username = entity.Username
            };
            
            return View(model);
        }
        
         [HttpPost("{id}/eliminar")]
        public virtual IActionResult DeleteConfirm(Int32 id)
        {
            var entity = Db.Usuario.Find(id);
            
            if (entity == null)
            {
                return HttpNotFound();
            }
            
            var personaFisicaId = entity.PersonaFisica.PersonaFisicaId;
            
            Db.Usuario.Remove(entity);
            Db.SaveChanges();
            
            return RedirectToAction("Detail", "PersonaFisica", new { id = personaFisicaId });
        }
    }
}