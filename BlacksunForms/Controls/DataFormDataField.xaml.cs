using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blacksun.XamForms.Enums;
using Blacksun.XamForms.Resources;
using Xamarin.Forms;

namespace Blacksun.XamForms.Controls
{
    public partial class DataFormDataField
    {

        public static BindableProperty DataMemberBindingProperty =
        BindableProperty.Create<DataFormDataField, object>(ctrl => ctrl.DataMemberBinding,
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (DataFormDataField)bindable;
            ctrl.DataMemberBinding = newValue;
        });


        public object DataMemberBinding
        {
            get { return (object)GetValue(DataMemberBindingProperty); }
            set
            {
                SetValue(DataMemberBindingProperty, value.ToString());
                TextField.Text = value.ToString();
            }
        }

        public DataFormDataField()
        {
            InitializeComponent();
            TextField.PropertyChanged += (o, t) =>
            {
                if (t.PropertyName == "Text")
                {
                    SetValue(DataMemberBindingProperty,TextField.Text);
                }
            };
        }

        public Label LabelField = new Label()
        {
            Font = AppFonts.FormLabelFont,
            TextColor = AppColors.FormLabelColor,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        public Keyboard Keyboard
        {
            get { return TextField.Keyboard; }
            set { TextField.Keyboard = value; }
        }

        private LabelType _labelType = LabelType.Label;
        public LabelType LabelType
        {
            get { return _labelType; }
            set
            {
                _labelType = value;

                TextField.Placeholder = "";

                if (Container.Children.Contains(LabelField))
                    Container.Children.Remove(LabelField);

                switch (LabelType)
                {
                    case LabelType.None:

                        break;
                    case LabelType.Label:

                        Container.Children.Insert(0, LabelField);
                        break;
                    case LabelType.Watermark:
                        TextField.Placeholder = Label;
                        break;
                }
            }
        }

        private string _label;
        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;

                TextField.Placeholder = "";
                LabelField.Text = "";

                if (Label != null)
                {
                    switch (LabelType)
                    {
                        case LabelType.None:

                            break;
                        case LabelType.Label:
                            LabelField.Text = value;
                            if (!Container.Children.Contains(LabelField))
                            {
                                Container.Children.Insert(0, LabelField);
                            }
                            break;
                        case LabelType.Watermark:
                            TextField.Placeholder = value;
                            break;
                    }
                }

            }
        }

        private string _dataMemberBindingPath;
        public string DataMemberBindingPath
        {
            get { return _dataMemberBindingPath; }
            set
            {
                _dataMemberBindingPath = value;
                TextField.SetBinding(Entry.TextProperty, new Binding(value, BindingMode.TwoWay));
            }
        }


    }
}
