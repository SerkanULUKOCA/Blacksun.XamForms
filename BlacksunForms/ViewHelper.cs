using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Input;
using BlacksunForms.CustomControls;
using BlacksunForms.Helpers;
using BlacksunForms.Layouts;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms
{

    

    public static class ViewHelper
    {

        

        public static StackLayout GetCenteredForm(IList<View> fields)
        {
            var result = new StackLayout
            {
                Spacing = 20,
                Padding = 50,
                VerticalOptions = LayoutOptions.Center,
            };

            foreach (var field in fields)
            {
                result.Children.Add(field);
            }

            return result;
        }
        
    }
}
