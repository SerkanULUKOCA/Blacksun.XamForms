using System.Collections.Generic;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms.Layouts
{

    public class FormConfig
    {

        public FormConfig()
        {
            Padding = 30;
            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;
        }

        public LayoutOptions VerticalOptions { get; set; }

        public LayoutOptions HorizontalOptions { get; set; }

        public Thickness Padding { get; set; }
    }

    public class FormLayout : ScrollView
    {

        public FormLayout()
        {
            
        }

        public FormLayout(IList<GroupLayout> groups, FormConfig config = null)
        {

            Groups = new List<GroupLayout>();

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

            Content = result;
        }

        public List<GroupLayout> Groups { get; set; }

        public StackLayout Layout { get; set; }

    }



}
