using System;

namespace MingaDigital.App.ApiModels
{
    public class NameSearchApiModel<KeyT>
    {
        public KeyT Key { get; set; }
        
        public String Value { get; set; }
    }
}