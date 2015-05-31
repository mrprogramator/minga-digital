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
        private readonly UserSessionService _service;
        
        public UserSessionFilter(UserSessionService service)
        {
            _service = service;
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            
            if (actionDescriptor == null) return;
            
            var allowAnon = actionDescriptor.MethodInfo.GetCustomAttribute<AllowAnonymousAttribute>();
            
            var session = _service.ActiveUserSession;
            
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