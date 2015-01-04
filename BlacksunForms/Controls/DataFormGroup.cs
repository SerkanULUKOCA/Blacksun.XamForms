using System.Collections.Generic;
using Blacksun.XamForms.Resources;
using Xamarin.Forms;

namespace Blacksun.XamForms.Controls
{
    public class DataFormGroup : ContentView 
    {

        private StackLayout ContentLayout = new StackLayout(){Spacing = AppLayouts.FormPropertiesSpacing};

        private StackLayout FormGroupLayout = new StackLayout() { Spacing = AppLayouts.FormGroupLabelSpacing, VerticalOptions = LayoutOptions.StartAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = 0 };

        public string Header
        {
            get { return HeaderLabel.Text; }
            set
            {
                if (value != null)
                {
                    FormGroupLayout.Children.Insert(0,HeaderLabel);
                }
                else
                {
                    if (FormGroupLayout.Children.Contains(HeaderLabel))
                    FormGroupLayout.Children.Remove(HeaderLabel);
                }
                HeaderLabel.Text = value;

            }
        }

        public DataFormGroup()
        {
            Init();
        }

        public void Init()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            
            
            /*
            var groupContent = new StackLayout();
            groupContent.Spacing = AppLayouts.FormPropertiesSpacing;
            */
            //Spacing = AppLayouts.FormGroupLabelSpacing;
            /*
            HeaderLabel = new Label
            {
                Text = Header,
                Font = AppFonts.FormGroupFont,
                TextColor = AppColors.FormGroupColor,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };*/
            /*
            if (Header != null)
            {
                
                FormGroupLayout.Children.Add(HeaderLabel);
            }*/

            FormGroupLayout.Children.Add(ContentLayout);

            //Children.Add(ContentLayout);
            /*
            foreach (var field in fields)
            {
                groupContent.Children.Add(field);
                Fields.Add(field);
            }*/

            Content = FormGroupLayout;

        }

        private Label HeaderLabel = new Label
        {
            Text = "",
            Font = AppFonts.FormGroupFont,
            TextColor = AppColors.FormGroupColor,
            HorizontalOptions = LayoutOptions.StartAndExpand,
        };

        public IList<View> Children
        {
            get { return ContentLayout.Children; }
        }

    }
}
