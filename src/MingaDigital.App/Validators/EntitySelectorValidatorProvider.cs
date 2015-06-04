using Microsoft.AspNet.Mvc.ModelBinding.Validation;

using MingaDigital.App.EF;
using MingaDigital.App.Models;

namespace MingaDigital.App.Validators
{
    public class EntitySelectorValidatorProvider : IModelValidatorProvider
    {
        private EntitySelectorValidator Validator { get; }
        
        public EntitySelectorValidatorProvider(MainContext db)
        {
            Validator = new EntitySelectorValidator(db);
        }
        
        public void GetValidators(ModelValidatorProviderContext context)
        {
            var modelType = context.ModelMetadata.ModelType;
            
            if (typeof(EntitySelector).IsAssignableFrom(modelType))
            {
                context.Validators.Add(Validator);
            }
        }
    }
}