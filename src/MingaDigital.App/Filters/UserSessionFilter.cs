using System;
using System.Linq;
using System.Reflection;
using System.Data.Entity;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;

namespace MingaDigital.App.Filters
{
    public class UserSessionFilter : IActionFilter
    {
        private readonly MainContext _db;
        
        public UserSessionFilter(MainContext db)
        {
            _db = db;
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            
            if (actionDescriptor == null) return;
            
            var allowAnon = actionDescriptor.MethodInfo.GetCustomAttribute<AllowAnonymousAttribute>();
            
            // TODO factorizar logica de sesion
            SesionUsuario session = null;
            var sessionId = context.HttpContext.Request.Cookies.Get("session_token");
            
            if (sessionId != null)
            {
                session =
                    _db.SesionUsuario
                    .Include(x => x.Usuario)
                    .Include(x => x.Usuario.PersonaFisica)
                    .FirstOrDefault(x => x.Id == sessionId);
                
                if (session == null)
                {
                    context.HttpContext.Response.Cookies.Delete("session_token");
                }
                else
                {
                    if (session.FechaHoraExpiracion <= DateTimeOffset.UtcNow)
                    {
                        _db.SesionUsuario.Remove(session);
                        _db.SaveChanges();
                        session = null;
                    }
                }
            }
            
            if (allowAnon == null && session == null)
            {
                context.Result = new RedirectToActionResult("Login", "Usuario", routeValues: null);
            }
        }
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}