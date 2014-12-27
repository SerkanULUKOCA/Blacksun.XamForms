using BlacksunForms.Layouts;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms.Controls
{
    public class DataFormDataField : ContentView
    {
        private StackLayout Container = new StackLayout() { Spacing = AppLayouts.LabelPropertySpacing, Padding = 0 };

        public Label LabelField = new Label(){
                Font = AppFonts.FormLabelFont,
                TextColor = AppColors.FormLabelColor,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
        public Entry TextField = new Entry()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        private Label ReadOnlyField = new Label()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        public Keyboard Keyboard
        {
            get { return TextField.Keyboard; }
            set { TextField.Keyboard = value; }
        }

        private bool _isReadOnly;
        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set
            {
                _isReadOnly = value;
                if (IsReadOnly)
                {
                    if (Container.Children.Contains(TextField))
                        Container.Children.Remove(TextField);

                    Container.Children.Add(ReadOnlyField);
                }
                else
                {
                    if (Container.Children.Contains(ReadOnlyField))
                        Container.Children.Remove(ReadOnlyField);

                    Container.Children.Add(ReadOnlyField);
                }
            }
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

                switch (LabelType)
                {
                    case LabelType.None:

                        break;
                    case LabelType.Label:
                        LabelField.Text = value;
                        if (!Container.Children.Contains(LabelField))
                        {
                            Container.Children.Insert(0,LabelField);
                        }
                        break;
                    case LabelType.Watermark:
                        TextField.Placeholder = value;
                        break;
                }
            }
        }

        private string _dataMemberBinding;
        public string DataMemberBinding
        {
            get { return _dataMemberBinding; }
            set
            {
                _dataMemberBinding = value;
                TextField.SetBinding(Entry.TextProperty, new Binding(value, BindingMode.TwoWay));
                ReadOnlyField.SetBinding(Xamarin.Forms.Label.TextProperty, new Binding(value, BindingMode.OneWay));
            }
        }

        public DataFormDataField()
        {
            Container.Children.Add(TextField);
            Content = Container;
        }

        
        

        //public Entry Content { get; set; }



    }
}
