using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blacksun.XamForms.Resources;
using BlacksunForms.Layouts;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms.Controls
{
    public class DataFormImageField : ContentView
    {

        private Image ImageField = new Image() { HorizontalOptions = LayoutOptions.FillAndExpand };
        public Label LabelField = new Label()
        {
            Font = AppFonts.FormLabelFont,
            TextColor = AppColors.FormLabelColor,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        private StackLayout Container = new StackLayout() { Spacing = AppLayouts.LabelPropertySpacing, Padding = 0 };

        private string _label;
        public string Label
        {
            get { return LabelField.Text; }
            set
            {
                LabelField.Text = value;

            }
        }

        private string _dataMemberBindingPath;
        public string DataMemberBindingPath
        {
            get { return _dataMemberBindingPath; }
            set
            {
                _dataMemberBindingPath = value;
                ImageField.SetBinding(Image.SourceProperty, new Binding(value, BindingMode.TwoWay));
            }
        }

        public DataFormImageField()
        {
            Container.Children.Add(LabelField);
            Container.Children.Add(ImageField);
            Content = Container;
        }

        /*
        public DataFormImageField(string labelText, string propertyPath, Aspect aspect = Aspect.AspectFit)
        {
            var binding = new Binding(propertyPath, BindingMode.TwoWay);

            this.Spacing = AppLayouts.LabelPropertySpacing;
            this.Padding = 0;

            if (labelText != null)
            {
                var label = GetLabel(labelText);
                Children.Add(label);

                Label = label;
            }

            var image = new Image();
            image.SetBinding(Image.SourceProperty, binding);

            Children.Add(image);

            Content = image;

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
        */
    }
}
