using System;
using Blacksun.XamForms.Resources;
using Xamarin.Forms;

namespace Blacksun.XamForms.Controls
{
    public class DataFormReadOnlyField: ContentView
    {


        private StackLayout Container = new StackLayout() { Spacing = AppLayouts.LabelPropertySpacing, Padding = 0 };

        public Label LabelField = new Label(){
                Font = AppFonts.FormLabelFont,
                TextColor = AppColors.FormLabelColor,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };


        private Label TextField = new Label()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand
        };
        
        private string _label;
        public string Label
        {
            get { return LabelField.Text; }
            set
            {
                LabelField.Text = value;
                if (String.IsNullOrEmpty(Label))
                {
                    if (Container.Children.Contains(LabelField))
                        Container.Children.Remove(LabelField);
                }
                else
                {
                    if(!Container.Children.Contains(LabelField))
                        Container.Children.Insert(0,LabelField);
                }
            }
        }

        public string DataMemberBinding
        {
            get { return TextField.Text; }
            set
            {
                TextField.Text = value;
                OnPropertyChanged();
            }
        }

        private string _dataMemberBindingPath;
        public string DataMemberBindingPath
        {
            get { return _dataMemberBindingPath; }
            set
            {
                _dataMemberBindingPath = value;
                TextField.SetBinding(Xamarin.Forms.Label.TextProperty, new Binding(value, BindingMode.TwoWay));
            }
        }


        public DataFormReadOnlyField()
        {
            Container.Children.Add(TextField);
            Content = Container;

        }

        
        

        //public Entry Content { get; set; }



    }
}
