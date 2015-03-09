using Blacksun.XamForms.Resources;
using Xamarin.Forms;

namespace Blacksun.XamForms.Controls
{
    public class DataFormSliderField : ContentView
    {

        public static BindableProperty DataMemberBindingProperty =
        BindableProperty.Create<DataFormSliderField, double>(ctrl => ctrl.DataMemberBinding,
        defaultValue: 0,
        defaultBindingMode: BindingMode.Default,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (DataFormSliderField)bindable;
            ctrl.DataMemberBinding = newValue;
        });


        public double DataMemberBinding
        {
            get { return (double)GetValue(DataMemberBindingProperty); }
            set
            {
                SetValue(DataMemberBindingProperty, value);
                SliderField.Value = value;
            }
        }

        private Slider SliderField = new Slider() {HorizontalOptions = LayoutOptions.FillAndExpand};

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
        /*
        public double DataMemberBinding
        {
            get { return SliderField.Value; }
            set
            {
                SliderField.Value = value;
                OnPropertyChanged();
            }
        }*/

        private string _dataMemberBindingPath;
        public string DataMemberBindingPath
        {
            get { return _dataMemberBindingPath; }
            set
            {
                _dataMemberBindingPath = value;
                SliderField.SetBinding(Slider.ValueProperty, new Binding(value, BindingMode.TwoWay));
            }
        }

        public double Minimum
        {
            get { return SliderField.Minimum; }
            set
            {
                SliderField.Minimum = value;
            }
        }

        public double Maximum
        {
            get { return SliderField.Maximum; }
            set
            {
                SliderField.Maximum = value;
            }
        }

        public DataFormSliderField()
        {
            SliderField.PropertyChanged += (o, t) =>
            {
                if (t.PropertyName == "Value")
                {
                    SetValue(DataMemberBindingProperty,SliderField.Value);
                }
            };
            Container.Children.Add(LabelField);
            Container.Children.Add(SliderField);
            Content = Container;
        }

    }
}
