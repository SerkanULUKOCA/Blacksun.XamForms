using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using BlacksunForms.CustomControls;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms
{

    public enum LabelType
    {
        None,
        Label,
        Watermark,
        WatermarkLabel
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

        public static StackLayout GetFormGroup(string groupLabel,IList<View> fields)
        {

            var groupContent = new StackLayout();
            groupContent.Spacing = AppLayouts.FormPropertiesSpacing;

            var result = new StackLayout
            {
                Spacing = AppLayouts.FormGroupLabelSpacing,
                Children =
                {

                    new Label
                            {
                                Text = groupLabel,
                                Font = AppFonts.FormGroupFont,
                                TextColor = AppColors.FormGroupColor,
                                HorizontalOptions = LayoutOptions.StartAndExpand,
                            },
                    groupContent
                    
                }

            };

            foreach (var field in fields)
            {
                groupContent.Children.Add(field);
            }

            return result;
        }

        public static View GetForm(IList<View> fields, StackLayout layoutParameters = null)
        {

            

            if (layoutParameters == null)
            {
                layoutParameters = new StackLayout();
                layoutParameters.Padding = 30;
            }

            var result = new StackLayout
            {
                Spacing = AppLayouts.FormGroupsSpacing,
                VerticalOptions = layoutParameters.VerticalOptions,
                HorizontalOptions = layoutParameters.HorizontalOptions,
                Padding = layoutParameters.Padding
            };

            foreach (var field in fields)
            {
                result.Children.Add(field);
            }

            var scrollview = new ScrollView
            {
                Content = result
            };


            return scrollview;
        }

        public static StackLayout GetTextProperty(string labelName, string propertyBind, BindingMode bindingMode = BindingMode.TwoWay, Keyboard keyboard = null, LabelType labelType = LabelType.Label)
        {
            var binding = new Binding(propertyBind, bindingMode);

            var txtEntry = new Entry() { HorizontalOptions = LayoutOptions.FillAndExpand };
            txtEntry.SetBinding(Entry.TextProperty, binding);
            txtEntry.HorizontalOptions = LayoutOptions.FillAndExpand;

            var content = new StackLayout
            {
                Spacing = AppLayouts.LabelPropertySpacing,
                Padding = 0
            };

            if (labelName != null)
            {
                var label = GetLabel(labelName);

                switch (labelType)
                {
                    case LabelType.None:

                        break;
                    case LabelType.Label:

                        content.Children.Add(label);
                        break;
                    case LabelType.Watermark:
                        txtEntry.Placeholder = labelName;
                        break;
                    case LabelType.WatermarkLabel:
                        content.Children.Add(label);
                        txtEntry.Placeholder = labelName;
                        break;
                }
            }

            

            content.Children.Add(txtEntry);

            return content;
        }

        public static StackLayout GetReadOnlyTextProperty(string labelName, string propertyBind, LabelType labelType = LabelType.Label)
        {
            var binding = new Binding(propertyBind, BindingMode.OneWay);

            var txtEntry = new Label();
            txtEntry.TextColor = AppColors.FormReadOnlyColor;
            txtEntry.Font = AppFonts.FormReadOnlyFont;
            txtEntry.SetBinding(Label.TextProperty, binding);
            txtEntry.HorizontalOptions = LayoutOptions.FillAndExpand;

            var content = new StackLayout
            {
                Spacing = AppLayouts.LabelPropertySpacing,

            };

            var label = GetLabel(labelName);

            switch (labelType)
            {
                case LabelType.None:

                    break;
                case LabelType.Label:

                    content.Children.Add(label);
                    break;
                case LabelType.Watermark:
                    break;
                case LabelType.WatermarkLabel:
                    content.Children.Add(label);
                    break;
            }

            content.Children.Add(txtEntry);

            return content;
        }

        public static Label GetLabel(string labelName)
        {
            var label = new Label
            {
                Text = labelName,
                Font = AppFonts.FormLabelFont,
                TextColor = AppColors.FormLabelColor,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            return label;
        }

        public static StackLayout GetLabelForContent(string labelName,View view)
        {

            var content = new StackLayout
            {
                Spacing = AppLayouts.LabelPropertySpacing,

            };

            var label = GetLabel(labelName);

            content.Children.Add(label);

            content.Children.Add(view);

            return content;
        }

        public static StackLayout GetPasswordProperty(string labelName, string propertyBind, BindingMode bindingMode = BindingMode.Default, Keyboard keyboard = null, LabelType labelType = LabelType.Label)
        {

            var content = GetTextProperty(labelName, propertyBind, bindingMode, keyboard, labelType);

            var query = content.Children.FirstOrDefault(x => x is Entry);

            if (query != null)
            {
                var entry = query as Entry;
                entry.IsPassword = true;
            }

            return content;
        }

        public static Button GetButton(string content,Color textColor,Color backgroundColor,ICommand command = null)
        {
            var button = new Button();
            button.Text = content;
            button.TextColor = textColor;
            button.BackgroundColor = backgroundColor;
            if (command != null)
            {
                button.Command = command;
            }
            return button;
        }

        public static StackLayout GetPickerProperty(string labelName, string propertyBind, string displayMemberPath, string valueMemberPath, IEnumerable<object> itemsSource, BindingMode bindingMode = BindingMode.TwoWay)
        {
            var binding = new Binding(propertyBind, bindingMode);

            var content = new StackLayout
            {
                Spacing = AppLayouts.LabelPropertySpacing,
                Padding = 0
            };

            if (labelName != null)
            {
                var label = GetLabel(labelName);
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

        public static StackLayout GetImageProperty(string labelName, string propertyBind,Aspect aspect = Aspect.AspectFit)
        {
            var binding = new Binding(propertyBind, BindingMode.TwoWay);

            var content = new StackLayout
            {
                Spacing = AppLayouts.LabelPropertySpacing,
                Padding = 0
            };

            if (labelName != null)
            {
                var label = GetLabel(labelName);
                content.Children.Add(label);
            }

            var mainControl = new Image();
            mainControl.SetBinding(Image.SourceProperty, binding);
            /*
            mainControl.HorizontalOptions = horizontalOptions;
            mainControl.VerticalOptions = verticalOptions;

            if (width>= 0)
            {
                mainControl.WidthRequest = width;
            }

            if (height >= 0)
            {
                mainControl.HeightRequest = height;
            }
            */
            

            content.Children.Add(mainControl);

            return content;
        }

    }
}
