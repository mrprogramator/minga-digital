using System;

namespace MingaDigital.App.Metadata
{
    public interface IAdditionalMetadataAttribute
    {
        String Key { get; }
        
        Object Value { get; }
    }
}