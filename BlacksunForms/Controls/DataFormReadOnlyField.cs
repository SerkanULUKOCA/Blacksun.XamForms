using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms.Controls
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
