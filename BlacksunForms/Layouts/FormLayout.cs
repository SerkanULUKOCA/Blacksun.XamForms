using System.Collections.Generic;
using BlacksunForms.Controls;
using Xamarin.Forms;

namespace BlacksunForms.Layouts
{

    

    public class FormLayout : ScrollView
    {

        public FormLayout()
        {
            
        }
        /*
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
        */
        public List<GroupLayout> Groups { get; set; }

        public StackLayout Layout { get; set; }

    }



}
