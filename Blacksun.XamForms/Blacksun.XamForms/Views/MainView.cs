using System.Collections.Generic;
using Blacksun.XamForms.Controls;
using Blacksun.XamForms.Enums;
using Blacksun.XamForms.Sample.Core.ViewModels;
using BlacksunForms;
using BlacksunForms.Layouts;
using Xamarin.Forms;

namespace Blacksun.XamForms.Sample.Core.Views
{
    public class MainView : ContentPage
    {

        public MainViewModel ViewModel
        {
            get { return BindingContext as MainViewModel; }
        }

        public MainView()
        {

            BindingContext = new MainViewModel();
            
            Content = new DataForm()
            {
                Children =
                {
                    new DataFormGroup()
                    {
                        Header = "Group",
                        Children =
                        {
                            new DataFormDataField(){Label = "Editable",DataMemberBindingPath = "Property"},
                            new DataFormDataField(){Label = "I am a watermarked Entry",DataMemberBindingPath = "WatermarkProperty",LabelType = LabelType.Watermark},
                            new DataFormReadOnlyField(){Label = "Read Only",DataMemberBindingPath = "Property"},
                            new DataFormEditorField(){Label = "Editor multiline",DataMemberBindingPath = "Lorem"},
                            new DataFormContentField(){Label = "Busy indicator",Content = new DataFormButton(){Text= "Show busy indicator",Command = ViewModel.LoadingCommand}},
                            new DataFormContentField(){Label = "Progress Dialog",Content = new DataFormButton(){Text= "Show Progress Dialog",Command = ViewModel.ProgressCommand}},
                            new DataFormPickerField(){Label = "Picker",DatamemberBindingPath = "CustomerID",DisplayMemberPath="Name",SelectedValueMemberPath = "ID",ItemSourcePath = "Customers"},
                            new DataFormReadOnlyField(){Label = "Picker Selected Value",DataMemberBindingPath = "CustomerID"},
                            new DataFormSliderField(){Label= "Slider",DataMemberBindingPath="SliderValue",Minimum = 0,Maximum = 255},
                            new DataFormImageField(){Label = "Image",DataMemberBindingPath = "ImageSource"}
                        }
                    }

                }
            };

        }

    }
}
