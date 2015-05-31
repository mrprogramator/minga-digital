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
        [FromServices]
        public MainContext Db { get; set; }
        
        public UserSessionFilter(MainContext db)
        {
            Db = db;
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            
            if (actionDescriptor == null) return;
            
            var allowAnon = actionDescriptor.MethodInfo.GetCustomAttribute<AllowAnonymousAttribute>();
            
            if (Db == null) throw new Exception("WHAT");
            
            // TODO factorizar logica de sesion
            SesionUsuario session = null;
            var sessionId = context.HttpContext.Request.Cookies.Get("session_token");
            
            if (sessionId != null)
            {
                session =
                    Db.SesionUsuario
                    .Include(x => x.Usuario)
                    .Include(x => x.Usuario.PersonaFisica)
                    .FirstOrDefault(x => x.Id == sessionId);
                
                if (session != null)
                {
                    if (session.FechaHoraExpiracion <= DateTimeOffset.UtcNow)
                    {
                        Db.SesionUsuario.Remove(session);
                        Db.SaveChanges();
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