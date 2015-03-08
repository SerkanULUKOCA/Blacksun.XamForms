using Blacksun.XamForms.Resources;
using Xamarin.Forms;

namespace Blacksun.XamForms.Controls
{
    [ContentProperty("Content")]
    public class DataFormContentField : ContentView
    {

        public Label LabelField = new Label()
        {
            Font = AppFonts.FormLabelFont,
            TextColor = AppColors.FormLabelColor,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        public string Label
        {
            get { return LabelField.Text; }
            set
            {
                LabelField.Text = value;

            }
        }

        private StackLayout Container = new StackLayout() { Spacing = AppLayouts.LabelPropertySpacing, Padding = 0 };
        
        public DataFormContentField()
        {
            ((ContentView)this).Content = Container;
            ProcessContent();
        }

        private View _content;
        public new View Content
        {
            get { return _content; }
            set { _content = value; ProcessContent(); }
        }

        private void ProcessContent()
        {
            Container.Children.Clear();
            Container.Children.Add(LabelField);
            if (Content != null)
            {
                Container.Children.Add(Content);
            }
        }

        /*
        public DataFormContentField(string labelText, View view)
        {

            if (labelText != null)
            {
                var label = GetLabel(labelText);
                Children.Add(label);
                Label = label;
            }

            Children.Add(view);

            Content = view;
        }
        */

        
        
        
        public static Label GetLabel(string labelText)
        {
            var label = new Label
            {
                Text = labelText,
                Font = AppFonts.FormLabelFont,
                TextColor = AppColors.FormLabelColor,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            return label;

        }


    }
}
