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
    public class DataFormPasswordField : StackLayout
    {

        public DataFormPasswordField()
        {

        }

        public DataFormPasswordField(string labelText, string propertyBind, PropertyConfig properties = null)
        {
            if (properties == null)
            {
                properties = new PropertyConfig();
            }

            var binding = new Binding(propertyBind, properties.BindingMode);
            var txtEntry = new Entry() { HorizontalOptions = LayoutOptions.FillAndExpand };
            txtEntry.IsPassword = true;
            txtEntry.Keyboard = properties.Keyboard;
            txtEntry.SetBinding(Entry.TextProperty, binding);
            txtEntry.HorizontalOptions = LayoutOptions.FillAndExpand;
            Spacing = AppLayouts.LabelPropertySpacing;
            Padding = 0;


            if (labelText != null)
            {
                var label = GetLabel(labelText);
                this.Children.Add(label);
                Label = label;
            }

            this.Children.Add(txtEntry);


            Content = txtEntry;

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
