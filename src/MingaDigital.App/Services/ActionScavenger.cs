using System;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ApplicationModels;

using MingaDigital.App.Entities;

namespace MingaDigital.App.Services
{
    // NOTE singleton service!
    public class ActionScavenger
    {
        private readonly IControllerModelBuilder _applicationModelBuilder;
        private readonly IControllerTypeProvider _controllerTypeProvider;
        
        private readonly Lazy<IEnumerable<Accion>> _actionsTask;
        
        public ActionScavenger(IControllerTypeProvider controllerTypeProvider,
                               IControllerModelBuilder applicationModelBuilder)
        {
            _controllerTypeProvider = controllerTypeProvider;
            _applicationModelBuilder = applicationModelBuilder;
            
            _actionsTask = new Lazy<IEnumerable<Accion>>(Scavenge);
        }
        
        public IEnumerable<Accion> Actions => _actionsTask.Value;
        
        private IEnumerable<Accion> Scavenge()
        {
            var actions = new List<Accion>();
            
            foreach (var type in _controllerTypeProvider.ControllerTypes)
            {
                var controllerModel = _applicationModelBuilder.BuildControllerModel(type);
                
                if (controllerModel == null) continue;
                
                foreach (var actionModel in controllerModel.Actions)
                {
                    foreach (var httpMethod in actionModel.HttpMethods)
                    {
                        var keyParts = new[] {
                            httpMethod,
                            actionModel.ActionName,
                            controllerModel.ControllerName
                        };
                        
                        var key = String.Join(":", keyParts);
                        
                        var action = new Accion { AccionId = key };
                        
                        actions.Add(action);
                    }
                }
            }
            
            return actions;
        }
    }
}