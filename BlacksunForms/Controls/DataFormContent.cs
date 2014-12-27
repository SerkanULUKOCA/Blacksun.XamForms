using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksunForms.Layouts;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms.Controls
{
    public class DataFormContent : StackLayout
    {

        public DataFormContent()
        {
            
        }

        public DataFormContent(string labelText, View view)
        {

            if (labelText != null)
            {
                var label = GetLabel(labelText);
                Children.Add(label);
                Label = label;
            }

            Children.Add(view);

            Content = view;
        }

        public Label Label { get; set; }

        public View Content { get; set; }

        public static Label GetLabel(string labelText)
        {
            var label = new Label
            {
                Text = labelText,
                Font = AppFonts.FormLabelFont,
                TextColor = AppColors.FormLabelColor,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            return label;

        }


    }
}
