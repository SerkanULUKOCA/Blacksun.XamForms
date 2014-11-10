using System.Collections.Generic;
using Blacksun.XamForms.Sample.Core.ViewModels;
using BlacksunForms;
using BlacksunForms.CustomControls;
using BlacksunForms.Layouts;
using BlacksunForms.Resources;
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
            
            Content = ViewHelper.GetForm(new List<GroupLayout>
            {
                ViewHelper.GetFormGroup("Group", new List<View>
                {
                    ViewHelper.GetTextProperty("Editable", "Property"),
                    ViewHelper.GetTextProperty("I am a watermarked Entry", "WatermarkProperty", new PropertyConfig(){LabelType = LabelType.Watermark}),
                    ViewHelper.GetReadOnlyTextProperty("Read Only", "Property"),
                    ViewHelper.GetPasswordProperty("Password", "Property"),
                    ViewHelper.GetLabelForContent("Busy indicator",ViewHelper.GetButton("Show busy indicator",ViewModel.LoadingCommand)),
                    ViewHelper.GetLabelForContent("Progress bar",ViewHelper.GetButton("Show progress bar",ViewModel.ProgressCommand)),
                    ViewHelper.GetPickerProperty("Picker","CustomerID","Name","ID",ViewModel.Customers),
                    ViewHelper.GetReadOnlyTextProperty("Picker Selected Value", "CustomerID"),
                    ViewHelper.GetSliderProperty("Slider", "SliderValue",0,255),
                    ViewHelper.GetImageProperty("Image", "ImageSource"),
                })
            });
        }

    }
}
