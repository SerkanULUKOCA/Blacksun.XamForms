using BlacksunForms.CustomControls;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms.Controls
{
    public class DataFormPickerField : ContentView
    {

        public Label LabelField = new Label()
        {
            Font = AppFonts.FormLabelFont,
            TextColor = AppColors.FormLabelColor,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        public string Label
        {
            get { return LabelField.Text; }
            set
            {
                LabelField.Text = value;

            }
        }

        private StackLayout Container = new StackLayout() { Spacing = AppLayouts.LabelPropertySpacing, Padding = 0 };

        BindablePicker Picker = new BindablePicker()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
        };

        public string DisplayMemberPath
        {
            get { return Picker.DisplayMemberPath; }
            set { Picker.DisplayMemberPath = value; }
        }

        public string SelectedValueMemberPath
        {
            get { return Picker.SelectedValueMemberPath; }
            set { Picker.SelectedValueMemberPath = value; }
        }

        private string _dataMemberBindingPath;
        public string DatamemberBindingPath
        {
            get { return _dataMemberBindingPath; }
            set
            {
                _dataMemberBindingPath = value;
                var binding = new Binding(value,BindingMode.TwoWay);
                Picker.SetBinding(BindablePicker.SelectedValueProperty, binding);
            }
        }

        private string _itemSourcePath;
        public string ItemSourcePath
        {
            get { return _itemSourcePath; }
            set
            {
                _itemSourcePath = value;
                var binding = new Binding(value, BindingMode.TwoWay);
                Picker.SetBinding(BindablePicker.ItemsSourceProperty, binding);
            }
        }

        public DataFormPickerField()
        {
            Container.Children.Clear();
            Container.Children.Add(LabelField);
            Container.Children.Add(Picker);
            Content = Container;
        }



        /*
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

        */
    }
}
