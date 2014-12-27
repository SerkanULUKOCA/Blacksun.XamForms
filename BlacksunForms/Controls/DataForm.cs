using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksunForms.Layouts;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms.Controls
{
    /*
    public class FormConfig
    {

        public FormConfig()
        {
            Padding = 30;
            VerticalOptions = LayoutOptions.StartAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;
        }

        public LayoutOptions VerticalOptions { get; set; }

        public LayoutOptions HorizontalOptions { get; set; }

        public Thickness Padding { get; set; }
    }
    */
    public class DataForm : ScrollView
    {

        private StackLayout ContentLayout = new StackLayout();

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

        public DataForm()
        {
            Init();
        }

        private void Init()
        {

            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;

            /*
            FormLayout.Spacing = AppLayouts.FormGroupsSpacing;

            Padding = 30;

            if (config == null)
            {
                config = new FormConfig();
            }
            
            var result = new StackLayout
            {
                Spacing = AppLayouts.FormGroupsSpacing,
                VerticalOptions = config.VerticalOptions,
                HorizontalOptions = config.HorizontalOptions,
                Padding = config.Padding
            };

            foreach (var group in groups)
            {
                result.Children.Add(group);
                Groups.Add(group);
            }
             * 
             * */

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
