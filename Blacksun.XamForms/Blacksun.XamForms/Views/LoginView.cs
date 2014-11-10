using System.Collections.Generic;
using Blacksun.XamForms.Sample.Core.ViewModels;
using BlacksunForms;
using BlacksunForms.CustomControls;
using BlacksunForms.Layouts;
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
                ViewHelper.GetTextProperty("Username", "Username",new PropertyConfig{LabelType = LabelType.Watermark}),
                ViewHelper.GetPasswordProperty("Password", "Password",new PropertyConfig{LabelType = LabelType.Watermark}),
                ViewHelper.GetButton("Login",null),
                
            });
        }

    }
}
