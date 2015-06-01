using System;
using System.Linq;
using System.Reflection;
using System.Data.Entity;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Services;

namespace MingaDigital.App.Filters
{
    public class UserSessionFilter : IActionFilter
    {
        private readonly UserSessionService _userSession;
        private readonly UserPermissionsService _userPermissions;
        
        public UserSessionFilter(UserSessionService userSession,
                                 UserPermissionsService userPermissions)
        {
            _userSession = userSession;
            _userPermissions = userPermissions;
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            
            if (actionDescriptor == null) return;
            
            var allowAnon = actionDescriptor.MethodInfo.GetCustomAttribute<AllowAnonymousAttribute>();
            
            var session = _userSession.ActiveUserSession;
            
            if (allowAnon != null)
            {
                return;
            }
            
            if (session == null)
            {
                context.Result = new RedirectToActionResult("Login", "Usuario", routeValues: null);
                return;
            }
            
            // TODO below: weird & hacky
            
            var controllerName = context.Controller.GetType().Name;
            
            if (controllerName.EndsWith("Controller"))
            {
                controllerName =
                    controllerName.Substring(
                        0, controllerName.Length - "Controller".Length
                    );
            }
            
            var actionIdParts = new[] {
                context.HttpContext.Request.Method,
                context.ActionDescriptor.Name,
                controllerName
            };
            
            var actionId = String.Join(":", actionIdParts);
            
            if (!_userPermissions.CanCallAction(actionId))
            {
                // TODO send 403?
                // context.Result = new RedirectToActionResult("Forbidden", "Usuario", routeValues: null);
                return;
            }
        }
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}