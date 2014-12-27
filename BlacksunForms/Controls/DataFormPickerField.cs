using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksunForms.CustomControls;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms.Controls
{
    public class DataFormPickerField : StackLayout
    {

        public DataFormPickerField()
        {
            
        }

        public DataFormPickerField(string labelText, string propertyBind, string displayMemberPath, string valueMemberPath, string itemsSourcePath, BindingMode bindingMode = BindingMode.TwoWay)
        {
            var binding = new Binding(propertyBind, bindingMode);
            var itemsourceBinding = new Binding(itemsSourcePath, bindingMode);

            Spacing = AppLayouts.LabelPropertySpacing;
            Padding = 0;

            if (labelText != null)
            {
                var label = GetLabel(labelText);
                this.Children.Add(label);
                Label = label;
            }

            var mainControl = new BindablePicker()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                DisplayMemberPath = displayMemberPath,
                SelectedValueMemberPath = valueMemberPath,
            };

            mainControl.SetBinding(BindablePicker.SelectedValueProperty, binding);
            mainControl.SetBinding(BindablePicker.ItemsSourceProperty, itemsourceBinding);
            mainControl.HorizontalOptions = LayoutOptions.FillAndExpand;

            Content = mainControl;

            this.Children.Add(mainControl);
        }

        public Label Label { get; set; }

        public BindablePicker Content { get; set; }

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

        public object SelectedItem
        {
            get { return Content.SelectedItem; }
            set { Content.SelectedItem = value; }

        }


    }
}
