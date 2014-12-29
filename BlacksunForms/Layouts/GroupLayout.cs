using System.Collections.Generic;
using Blacksun.XamForms.Resources;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms.Layouts
{
    public class GroupLayout : StackLayout
    {

        public GroupLayout(string groupLabel, IList<View> fields)
        {

            Fields = new List<View>();

            var groupContent = new StackLayout();
            groupContent.Spacing = AppLayouts.FormPropertiesSpacing;

            Spacing = AppLayouts.FormGroupLabelSpacing;

            Children.Add(new Label
                                 {
                                     Text = groupLabel,
                                     Font = AppFonts.FormGroupFont,
                                     TextColor = AppColors.FormGroupColor,
                                     HorizontalOptions = LayoutOptions.StartAndExpand,
                                 });

            Children.Add(groupContent);

            foreach (var field in fields)
            {
                groupContent.Children.Add(field);
                Fields.Add(field);
            }

        }

        public List<View> Fields { get; set; } 

    }
}
