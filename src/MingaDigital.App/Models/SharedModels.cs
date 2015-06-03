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
    
    public class EntitySelectorModel
    {
        public String Key { get; set; }
        
        public String Value { get; set; }
    }
}