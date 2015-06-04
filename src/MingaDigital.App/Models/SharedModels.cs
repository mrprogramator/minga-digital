using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Mvc;

namespace MingaDigital.App.Models
{
    public class BasicIndexModel<RowT>
    {
        public BasicTable<RowT> Table { get; set; }
    } 
    
    public class BasicTable<RowT>
    {
        public IEnumerable<RowT> Rows { get; set; }
    }
    
    public class GroupedTable<KeyT, RowT>
    {
        public IEnumerable<TableGroup<KeyT, RowT>> Groups { get; set; }
    }
    
    public class TableGroup<KeyT, RowT>
    {
        public KeyT Key { get; set; }
        
        public IEnumerable<RowT> Rows { get; set; }
    }
    
    [Bind("Key")]
    public abstract class EntitySelector<EntityT, KeyT> : EntitySelector
    {
        public EntityT Entity { get; set; }
        
        // KeyT debe admitir null!
        // sino model binding lo vuelve requerido
        // nosotros nos encargamos manualmente de RequiredAttribute
        public KeyT Key { get; set; }
        
        public abstract String DisplayValue { get; }
        
        public static implicit operator EntityT(EntitySelector<EntityT, KeyT> selector) =>
            selector.Entity;
    }
    
    // Used as UIHint
    public abstract class EntitySelector { }
}