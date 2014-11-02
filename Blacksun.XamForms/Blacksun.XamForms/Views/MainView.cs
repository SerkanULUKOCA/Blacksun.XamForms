using System.Collections.Generic;
using Blacksun.XamForms.Sample.Core.ViewModels;
using BlacksunForms;
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

            Content = ViewHelper.GetForm(new List<View>
            {
                ViewHelper.GetFormGroup("Group", new List<View>
                {
                    ViewHelper.GetTextProperty("Editable", "Property"),
                    ViewHelper.GetTextProperty("Place holder", "Property",labelType:LabelType.WatermarkLabel),
                    ViewHelper.GetReadOnlyTextProperty("Read Only", "Property"),
                    ViewHelper.GetPasswordProperty("Password", "Property"),
                    ViewHelper.GetLabelForContent("Busy indicator",ViewHelper.GetButton("Show busy indicator",Color.White,AppColors.Accent,ViewModel.LoadingCommand)),
                    ViewHelper.GetLabelForContent("Progress bar",ViewHelper.GetButton("Show progress bar",Color.White,AppColors.Accent,ViewModel.ProgressCommand)),
                    ViewHelper.GetPickerProperty("Picker","CustomerID","Name","ID",ViewModel.Customers),
                    ViewHelper.GetReadOnlyTextProperty("Picker Selected Value", "CustomerID"),
                    ViewHelper.GetImageProperty("Image", "ImageSource"),
                })
            });
        }

    }
}
