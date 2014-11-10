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

    public enum LabelType
    {
        None,
        Label,
        Watermark
    }

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

        public static GroupLayout GetFormGroup(string groupLabel,IList<View> fields)
        {

            var content = new GroupLayout(groupLabel, fields);
            return content;
        }

        public static FormLayout GetForm(IList<GroupLayout> groups, FormConfig layoutParameters = null)
        {
            var content = new FormLayout(groups, layoutParameters);

            return content;
        }

        public static PropertyLayout GetTextProperty(string labelText, string propertyBind,PropertyConfig config = null)
        {
            var content = new PropertyLayout();
            content.InitiateAsEntry(labelText, propertyBind, config);
            return content;
        }

        public static PropertyLayout GetReadOnlyTextProperty(string labelText, string propertyBind, PropertyConfig config = null)
        {
            
            var content = new PropertyLayout();
            content.InitiateAsReadOnlyEntry(labelText, propertyBind, config);
            return content;
        }

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

        public static StackLayout GetLabelForContent(string labelText,View view)
        {
            
            var content = new PropertyLayout();
            content.InitiateWithContent(labelText, view);
            return content;

            return content;
        }

        public static StackLayout GetPasswordProperty(string labelText, string propertyBind, PropertyConfig config = null)
        {
            var content = new PropertyLayout();
            content.InitiateAsPasswordEntry(labelText, propertyBind, config);

            return content;
        }

        public static Button GetButton(string content,ICommand command,ButtonConfig config = null)
        {

            if (config == null)
            {
                config = new ButtonConfig();
            }

            var button = new Button();
            button.Text = content;
            button.TextColor = config.TextColor;
            button.BackgroundColor = config.BackgroundColor;
            if (command != null)
            {
                button.Command = command;
            }
            return button;
        }

        public static StackLayout GetPickerProperty(string labelText, string propertyBind, string displayMemberPath, string valueMemberPath, IEnumerable<object> itemsSource, BindingMode bindingMode = BindingMode.TwoWay)
        {
            var binding = new Binding(propertyBind, bindingMode);

            var content = new StackLayout
            {
                Spacing = AppLayouts.LabelPropertySpacing,
                Padding = 0
            };

            if (labelText != null)
            {
                var label = GetLabel(labelText);
                content.Children.Add(label);
            }

            var mainControl = new BlacksunFormsPicker()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                DisplayMemberPath =  displayMemberPath,
                SelectedValueMemberPath = valueMemberPath,
                ItemsSource = itemsSource
            };
            mainControl.SetBinding(BlacksunFormsPicker.SelectedValueProperty, binding);
            mainControl.HorizontalOptions = LayoutOptions.FillAndExpand;
            
            content.Children.Add(mainControl);

            return content;
        }

        public static StackLayout GetImageProperty(string labelText, string propertyBind,Aspect aspect = Aspect.AspectFit)
        {
            var binding = new Binding(propertyBind, BindingMode.TwoWay);

            var content = new StackLayout
            {
                Spacing = AppLayouts.LabelPropertySpacing,
                Padding = 0
            };

            if (labelText != null)
            {
                var label = GetLabel(labelText);
                content.Children.Add(label);
            }

            var mainControl = new Image();
            mainControl.SetBinding(Image.SourceProperty, binding);
            
            

            content.Children.Add(mainControl);

            return content;
        }

        public static PropertyLayout GetSliderProperty(string labelText, string propertyBind,double minValue = 0,double maxValue = 1, PropertyConfig config = null)
        {
            var content = new PropertyLayout();
            content.InitiateAsSlider(labelText, propertyBind, config);
            ((Slider) content.Content).Minimum = minValue;
            ((Slider) content.Content).Maximum = maxValue;
            return content;
        }

    }
}
