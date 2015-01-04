using System.Collections.Generic;
using Xamarin.Forms;

namespace Blacksun.XamForms
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
