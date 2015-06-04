using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Mvc.ModelBinding.Validation;

using MingaDigital.App.EF;

namespace MingaDigital.App.Validators
{
    public class EntitySelectorValidator : IModelValidator
    {
        private MainContext Db { get;}
        
        public EntitySelectorValidator(MainContext db)
        {
            Db = db;
        }
        
        public Boolean IsRequired => true;
        
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var modelExplorer = context.ModelExplorer;
            var modelMetadata = modelExplorer.Metadata;
            var modelType = modelExplorer.ModelType;
            var model = modelExplorer.Model;
            
            var requiredAttribute =
                modelExplorer
                .Container
                ?.ModelType
                ?.GetProperty(modelMetadata.PropertyName)
                ?.GetCustomAttribute<RequiredAttribute>();
            
            if (model == null)
                return null;
            
            var keyExplorer = modelExplorer.GetExplorerForProperty("Key");
            var keyType = keyExplorer.ModelType;
            var key = keyExplorer.Model;
            
            Object defaultKeyValue = null;
            
            if (keyType.IsValueType)
            {
                // TODO cache this somehow? tip: specialize validator & cache from provider
                defaultKeyValue = Activator.CreateInstance(keyType);
            }
            
            if ((key == null || key.Equals(defaultKeyValue) == true) && modelMetadata.IsRequired)
            {
                var message =
                    requiredAttribute?.FormatErrorMessage(modelMetadata.GetDisplayName());
                
                var result = new ModelValidationResult(context.RootPrefix, message);
                
                return new[] { result };
            }
            
            var entityExplorer = modelExplorer.GetExplorerForProperty("Entity");
            var entityType = entityExplorer.ModelType;
            
            var entity = Db.Set(entityType).Find(key);
            
            modelType.GetProperty("Entity").SetValue(model, entity);
            
            return Enumerable.Empty<ModelValidationResult>();
        }
    }
}