using System;

namespace MingaDigital.App.ApiModels
{
    public class NameSearchApiModel<KeyT>
    {
        public KeyT Id { get; set; }
        
        public String Name { get; set; }
    }
}