using System;
using System.Linq;
using System.Collections.Generic;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;

namespace MingaDigital.App.Services
{
    // NOTE scoped service!
    public class UserPermissionsService
    {
        private readonly MainContext _db;
        private readonly ActionScavenger _actionScavenger;
        private readonly UserSessionService _userSession;
        
        public UserPermissionsService(MainContext db,
                                      ActionScavenger actionScavenger,
                                      UserSessionService userSession)
        {
            _db = db;
            _actionScavenger = actionScavenger;
            _userSession = userSession;
        }
        
        public Boolean CanCallAction(String actionId)
        {
            var user = _userSession.ActiveUser;
            
            if (user == null)
                return false;
            
            var action = _db.Accion.Find(actionId);
            
            // TODO weird & hacky
            if (action == null)
            {
                var appAction = _actionScavenger.Actions.FirstOrDefault(x => x.AccionId == actionId);
                
                if (appAction == null)
                    throw new Exception("Action {actionId} does not exist.");
                
                action = _db.Accion.Add(appAction);
                _db.SaveChanges();
            }
            
            var canCall =
                GetCallableActionsQuery(user.UsuarioId)
                .Any(x => x.AccionId == actionId);
            
            return canCall;
        }
        
        public IEnumerable<Accion> GetCallableActions()
        {
            var user = _userSession.ActiveUser;
            
            if (user == null)
                return Enumerable.Empty<Accion>();
            
            var query = GetCallableActionsQuery(user.UsuarioId);
            
            var result = query.ToArray();
            
            return result;
        }
        
        private IQueryable<Accion> GetCallableActionsQuery(Int32 userId)
        {
            var rolesQuery =
                _db.UsuarioRol
                .Where(x => x.UsuarioId == userId)
                .SelectMany(x => _db.Rol.Where(y => y.RolId == x.RolId))
                .SelectMany(x => _db.PermisoRol.Where(y => y.RolId == x.RolId))
                .Select(x => x.Accion);
            
            var globalsQuery =
                _db.PermisoGlobal
                .Where(x => x.UsuarioId == userId)
                .Select(x => x.Accion);
            
            var query =
                rolesQuery
                .Union(globalsQuery);
            
            return query;
        }
    }
}