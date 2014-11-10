using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms.Layouts
{

    public class PropertyConfig
    {

        public PropertyConfig()
        {
            LabelType = LabelType.Label;
            BindingMode = BindingMode.TwoWay;
            Keyboard = Keyboard.Default;
        }

        public LabelType LabelType { get; set; }

        public BindingMode BindingMode { get; set; }

        public Keyboard Keyboard { get; set; }

    }

    public class PropertyLayout : StackLayout
    {

        public PropertyLayout()
        {
            
        }

        public PropertyLayout InitiateAsEntry(string labelName, string propertyBind, PropertyConfig properties = null)
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


            if (labelName != null)
            {
                var label = GetLabel(labelName);

                switch (properties.LabelType)
                {
                    case LabelType.None:

                        break;
                    case LabelType.Label:

                        this.Children.Add(label);
                        Label = label;
                        break;
                    case LabelType.Watermark:
                        txtEntry.Placeholder = labelName;
                        break;
                }
            }



            this.Children.Add(txtEntry);


            Content = txtEntry;

            return this;
        }

        public PropertyLayout InitiateAsReadOnlyEntry(string labelName, string propertyBind, PropertyConfig properties = null)
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


            if (labelName != null)
            {
                var label = GetLabel(labelName);

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

        public PropertyLayout InitiateAsPasswordEntry(string labelName, string propertyBind, PropertyConfig properties = null)
        {

            InitiateAsEntry(labelName, propertyBind, properties);

            var query = Content as Entry; 

            if (query != null)
            {
                var entry = query;
                entry.IsPassword = true;
            }

            return this;
        }

        public PropertyLayout InitiateWithContent(string labelName, View view,PropertyConfig properties = null)
        {
            if (properties == null)
            {
                properties = new PropertyConfig();
            }

            if (labelName != null)
            {
                var label = GetLabel(labelName);

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

        public Label Label { get; set; }

        public View Content { get; set; }


        public static Label GetLabel(string labelName)
        {
            var label = new Label
            {
                Text = labelName,
                Font = AppFonts.FormLabelFont,
                TextColor = AppColors.FormLabelColor,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            return label;

            

        }
        /*
        public static readonly BindableProperty IsVisibleProperty = BindableProperty.Create<BlacksunFormsPicker, object>(p => p.SelectedValue, null);

        public object IsVisible
        {
            get { return GetValue(IsVisibleProperty); }
            set
            {
                SetValue(IsVisibleProperty, value);
                OnPropertyChanged();
            }
        }
        */
    }
}
