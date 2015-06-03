using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc.ModelBinding.Metadata;

namespace MingaDigital.App.Metadata
{
    public class AdditionalMetadataProvider : IDisplayMetadataProvider
    {
        public void GetDisplayMetadata(DisplayMetadataProviderContext context)
        {
            Console.WriteLine("KEY: {0}", context.Key.Name);
            
            var xs = context.Attributes.Select(x => x.GetType().Name);
            Console.WriteLine(String.Join("\n", xs));
            
            var additionalMetadataAttributes =
                context.Attributes.OfType<IAdditionalMetadataAttribute>();
            
            foreach (var obj in additionalMetadataAttributes)
            {
                context.DisplayMetadata.AdditionalValues.Add(obj.Key, obj.Value);
            }
        }
    }
}