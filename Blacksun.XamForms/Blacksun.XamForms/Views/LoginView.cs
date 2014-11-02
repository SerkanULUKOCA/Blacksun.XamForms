using System.Collections.Generic;
using Blacksun.XamForms.Sample.Core.ViewModels;
using BlacksunForms;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace Blacksun.XamForms.Sample.Core.Views
{
    public class LoginView : ContentPage
    {

        public LoginViewModel ViewModel
        {
            get { return BindingContext as LoginViewModel; }
        }

        public LoginView()
        {
            Content = ViewHelper.GetCenteredForm(new List<View>
            {
                ViewHelper.GetTextProperty("Username", "Username",bindingMode:BindingMode.TwoWay,labelType:LabelType.Watermark),
                ViewHelper.GetPasswordProperty("Password", "Password",bindingMode:BindingMode.TwoWay,labelType:LabelType.Watermark),
                ViewHelper.GetButton("Login",Color.White,AppColors.Accent),
                
            });
        }

    }
}
