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
    public partial class DataFormDateField 
    {

        public static BindableProperty DataMemberBindingProperty =
        BindableProperty.Create<DataFormDateField, DateTime>(ctrl => ctrl.DataMemberBinding,
        defaultValue: DateTime.Now,
        defaultBindingMode: BindingMode.Default,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (DataFormDateField)bindable;
            ctrl.DataMemberBinding = newValue;
        });


        public DateTime DataMemberBinding
        {
            get { return (DateTime)GetValue(DataMemberBindingProperty); }
            set
            {
                SetValue(DataMemberBindingProperty, value);
                DateField.Date = value;
            }
        }

        public DataFormDateField()
        {
            InitializeComponent();
            DateField.PropertyChanged += (o, t) =>
            {
                if (t.PropertyName == "Date")
                {
                    SetValue(DataMemberBindingProperty, DateField.Date);
                }
            };
        }

        public Label LabelField = new Label()
        {
            Font = AppFonts.FormLabelFont,
            TextColor = AppColors.FormLabelColor,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        private LabelType _labelType = LabelType.Label;
        public LabelType LabelType
        {
            get { return _labelType; }
            set
            {
                _labelType = value;

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
                DateField.SetBinding(DatePicker.DateProperty, new Binding(value, BindingMode.TwoWay));
            }
        }


    }
}
