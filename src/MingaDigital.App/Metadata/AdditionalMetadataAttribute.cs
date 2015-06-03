using System;

namespace MingaDigital.App.Metadata
{
    [AttributeUsageAttribute(AttributeTargets.Class|AttributeTargets.Property|AttributeTargets.Interface, AllowMultiple = true)]
    public sealed class AdditionalMetadataAttribute : Attribute, IAdditionalMetadataAttribute
    {
        public String Key { get; }
        
        public Object Value { get; }
        
        public AdditionalMetadataAttribute(String key, String value)
        {
            Key = key;
            Value = value;
        }
    }
}