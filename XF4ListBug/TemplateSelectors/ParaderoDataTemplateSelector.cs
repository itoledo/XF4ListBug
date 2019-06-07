using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TSM4K.Models;
using Xamarin.Forms;

namespace TSM4K.TemplateSelectors
{
    public class ParaderoDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ParaderoCercanoNoCodeDataTemplate { get; set; }

        public DataTemplate ParaderoCercanoDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //Debug.WriteLine("OnSelectTemplate");
            var x = item as Paradero;
            if (x == null)
            {
                //Debug.WriteLine("OnSelectTemplate: null");
                return null;
            }

            if (string.IsNullOrEmpty(x.stop_code))
            {
                //Debug.WriteLine($"OnSelectTemplate: no stop code");
                return ParaderoCercanoNoCodeDataTemplate;
            }

            //Debug.WriteLine($"OnSelectTemplate: stop code {x.stop_code}");
            return ParaderoCercanoDataTemplate;
        }
    }
}
