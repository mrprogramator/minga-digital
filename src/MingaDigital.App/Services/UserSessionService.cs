using System;
using System.Linq;
using System.Data.Entity;

using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.Security;

namespace MingaDigital.App.Services
{
    // NOTE scoped service!
    public class UserSessionService
    {
        // TODO make this configurable?
        private static readonly String SessionCookieName = "session_token";
        
        private readonly ActionContext _actionContext;
        private readonly MainContext _db;
        
        private Lazy<SesionUsuario> _activeUserSessionTask;
        
        public UserSessionService(IScopedInstance<ActionContext> httpContext, MainContext db)
        {
            _actionContext = httpContext.Value;
            _db = db;
            _activeUserSessionTask = new Lazy<SesionUsuario>(GetActiveUserSession);
        }
        
        public SesionUsuario ActiveUserSession => _activeUserSessionTask.Value;
        
        public Usuario ActiveUser => ActiveUserSession?.Usuario;
        
        private SesionUsuario GetActiveUserSession()
        {
            var sessionToken = _actionContext.HttpContext.Request.Cookies.Get(SessionCookieName);
            
            if (sessionToken == null)
                return null;
            
            var session =
                _db.SesionUsuario
                .Include(x => x.Usuario)
                .Include(x => x.Usuario.PersonaFisica)
                .FirstOrDefault(x => x.Id == sessionToken);
            
            if (session == null)
            {
                _actionContext.HttpContext.Response.Cookies.Delete(SessionCookieName);
                return null;
            }
            
            if (session.FechaHoraExpiracion <= DateTimeOffset.UtcNow)
            {
                _db.SesionUsuario.Remove(session);
                _db.SaveChanges();
                return null;
            }
            
            return session;
        }
        
        public void StartUserSession(Usuario usuario)
        {
            var session = new SesionUsuario
            {
                Id = Guid.NewGuid().ToString(),
                Usuario = usuario,
                FechaHoraCreacion = DateTimeOffset.UtcNow,
                FechaHoraExpiracion = DateTimeOffset.UtcNow.AddMinutes(5)
            };
            
            _db.SesionUsuario.Add(session);
            _db.SaveChanges();
            
            // TODO hacky?
            _activeUserSessionTask = new Lazy<SesionUsuario>(() => session);
            
            _actionContext.HttpContext.Response.Cookies.Append(SessionCookieName, session.Id);
        }
        
        public void EndUserSession()
        {
            _db.SesionUsuario.Remove(ActiveUserSession);
            _db.SaveChanges();
            
            _actionContext.HttpContext.Response.Cookies.Delete(SessionCookieName);
        }
    }
}