using BlacksunForms.Enums;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms.Layouts
{

    public class PropertyConfig
    {

        public PropertyConfig()
        {

            BindingMode = BindingMode.TwoWay;
            Keyboard = Keyboard.Default;
            LabelType = LabelType.Label;
            LabelHorizontalPosition = LayoutOptions.FillAndExpand;
        }

        public bool IsReadOnly { get; set; }

        public LabelType LabelType { get; set; }

        public LayoutOptions LabelHorizontalPosition { get; set; }

        public BindingMode BindingMode { get; set; }

        public Keyboard Keyboard { get; set; }

    }
    /*
    public class PropertyLayout : StackLayout
    {

        public PropertyLayout()
        {
            
        }

        public PropertyLayout InitiateAsEntry(string labelText, string propertyBind, PropertyConfig properties = null)
        {

            if (properties == null)
            {
                properties = new PropertyConfig();
            }

            var binding = new Binding(propertyBind, properties.BindingMode);
            var txtEntry = new Entry() { HorizontalOptions = LayoutOptions.FillAndExpand };
            txtEntry.Keyboard = properties.Keyboard;
            txtEntry.SetBinding(Entry.TextProperty, binding);
            txtEntry.HorizontalOptions = LayoutOptions.FillAndExpand;
            Spacing = AppLayouts.LabelPropertySpacing;
            Padding = 0;


            if (labelText != null)
            {
                var label = GetLabel(labelText);

                switch (properties.LabelType)
                {
                    case LabelType.None:

                        break;
                    case LabelType.Label:

                        this.Children.Add(label);
                        Label = label;
                        break;
                    case LabelType.Watermark:
                        txtEntry.Placeholder = labelText;
                        break;
                }
            }



            this.Children.Add(txtEntry);


            Content = txtEntry;

            return this;
        }

        public PropertyLayout InitiateAsReadOnlyEntry(string labelText, string propertyBind, PropertyConfig properties = null)
        {

            if (properties == null)
            {
                properties = new PropertyConfig();
            }

            var binding = new Binding(propertyBind, properties.BindingMode);
            var txtEntry = new Label() { HorizontalOptions = LayoutOptions.FillAndExpand };
            txtEntry.SetBinding(Label.TextProperty, binding);
            txtEntry.HorizontalOptions = LayoutOptions.FillAndExpand;
            Spacing = AppLayouts.LabelPropertySpacing;
            Padding = 0;


            if (labelText != null)
            {
                var label = GetLabel(labelText);

                switch (properties.LabelType)
                {
                    case LabelType.None:

                        break;
                    case LabelType.Label:

                        this.Children.Add(label);
                        Label = label;
                        break;
                }
            }



            this.Children.Add(txtEntry);


            Content = txtEntry;

            return this;
        }

        public PropertyLayout InitiateAsPasswordEntry(string labelText, string propertyBind, PropertyConfig properties = null)
        {

            InitiateAsEntry(labelText, propertyBind, properties);

            var query = Content as Entry; 

            if (query != null)
            {
                var entry = query;
                entry.IsPassword = true;
            }

            return this;
        }

        public PropertyLayout InitiateWithContent(string labelText, View view,PropertyConfig properties = null)
        {
            if (properties == null)
            {
                properties = new PropertyConfig();
            }

            if (labelText != null)
            {
                var label = GetLabel(labelText);

                switch (properties.LabelType)
                {
                    case LabelType.None:

                        break;
                    case LabelType.Label:

                        this.Children.Add(label);
                        Label = label;
                        break;
                }
            }

            Content = view;

            return this;
        }

        public PropertyLayout InitiateAsSlider(string labelText, string propertyBind, PropertyConfig properties = null)
        {
            if (properties == null)
            {
                properties = new PropertyConfig();
            }

            var binding = new Binding(propertyBind, properties.BindingMode);
            var content = new SliderField() { HorizontalOptions = LayoutOptions.FillAndExpand };
            content.SetBinding(SliderField.ValueProperty, binding);
            content.HorizontalOptions = LayoutOptions.FillAndExpand;
            Spacing = AppLayouts.LabelPropertySpacing;
            Padding = 0;


            if (labelText != null)
            {
                var label = GetLabel(labelText);

                switch (properties.LabelType)
                {
                    case LabelType.None:

                        break;
                    case LabelType.Label:

                        this.Children.Add(label);
                        Label = label;
                        break;
                }
            }



            this.Children.Add(content);


            Content = content;

            return this;
        }

        public Label Label { get; set; }

        public View Content { get; set; }


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

    */
}
