using System.Collections.Generic;
using Blacksun.XamForms.Resources;
using Xamarin.Forms;

namespace Blacksun.XamForms.Controls
{
    [ContentProperty("Children")]
    public class DataForm : ScrollView
    {

        private StackLayout ContentLayout = new StackLayout() { Spacing = AppLayouts.FormGroupsSpacing, };

        private StackLayout FormLayout = new StackLayout() { Spacing = AppLayouts.FormGroupsSpacing,VerticalOptions = LayoutOptions.StartAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = 30 };

        public LayoutOptions VerticalOptions
        {
            get { return FormLayout.VerticalOptions; }
            set { FormLayout.VerticalOptions = value; }
        }

        public LayoutOptions HorizontalOptions
        {
            get { return FormLayout.HorizontalOptions; }
            set { FormLayout.HorizontalOptions = value; }
        }

        public double Spacing
        {
            get { return ContentLayout.Spacing; }
            set { ContentLayout.Spacing = value; }
        }

        public DataForm()
        {
            Init();
        }

        private void Init()
        {

            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;


            FormLayout.Children.Add(ContentLayout);

            Content = FormLayout;
        }


        //public List<GroupLayout> Groups { get; set; }

        public IList<View> Children
        {
            get { return ContentLayout.Children; }
        }

    }
    
}
