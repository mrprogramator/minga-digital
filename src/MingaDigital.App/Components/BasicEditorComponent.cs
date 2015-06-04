using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;

namespace MingaDigital.App.Components
{
    public class BasicEditorItem
    {
        public String PropertyName { get; set; }
        
        public HtmlString Label { get; set; }
        
        public HtmlString Editor { get; set; }
    }
    
    [ViewComponent(Name = "BasicEditor")]
    public class BasicEditorComponent : ViewComponent
    {
        public IViewComponentResult Invoke(HtmlHelper htmlHelper, Object model, String cancelUrl)
        {
            var items = new List<BasicEditorItem>();
            
            var modelType = model.GetType();
            
            var displayProps =
                from prop in modelType.GetProperties()
                let disp = prop.GetCustomAttribute<DisplayAttribute>()
                let readOnly = prop.GetCustomAttribute<ReadOnlyAttribute>()
                where disp != null
                select new
                {
                    Name = prop.Name,
                    Property = prop,
                    ReadOnly = readOnly?.IsReadOnly == true
                };
            
            foreach (var prop in displayProps)
            {
                HtmlString editor;
                
                if (prop.ReadOnly == true)
                {
                    editor =
                        htmlHelper.TextBox(
                            prop.Name,
                            null,
                            new { disabled = "disabled", @class = "form-control" }
                        );
                }
                else
                {
                    editor = htmlHelper.Editor(prop.Name);
                }
                
                var item = new BasicEditorItem
                {
                    PropertyName = prop.Name,
                    Label = htmlHelper.Label(prop.Name, null, new { @class = "control-label" }),
                    Editor = editor
                };
                
                items.Add(item);
            }
            
            ViewBag.CancelUrl = cancelUrl;
            
            return View(items);
        }
    }
}