using System;
using System.Collections;
using System.Collections.Generic;

namespace MingaDigital.App.Models
{
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
}