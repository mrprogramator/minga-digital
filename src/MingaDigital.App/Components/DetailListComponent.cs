using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;

namespace MingaDigital.App.Components
{
    public class DetailListItem
    {
        public String Name { get; set; }
        
        public HtmlString Value { get; set; }
    }
    
    [ViewComponent(Name = "DetailList")]
    public class DetailListComponent : ViewComponent
    {
        public IViewComponentResult Invoke(HtmlHelper htmlHelper, Object entity)
        {
            var items = new List<DetailListItem>();
            
            var properties = entity.GetType().GetProperties();
            
            foreach (var property in properties)
            {
                var displayAttr = property.GetCustomAttribute<DisplayAttribute>();
                
                if (displayAttr == null)
                    continue;
                
                var item = new DetailListItem
                {
                    Name    = htmlHelper.DisplayName(property.Name),
                    Value   = htmlHelper.Display(property.Name)
                };
                
                items.Add(item);
            }
            
            return View(items);
        }
    }
}