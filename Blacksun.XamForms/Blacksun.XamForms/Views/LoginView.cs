using System.Collections.Generic;
using Blacksun.XamForms.Enums;
using Blacksun.XamForms.Sample.Core.ViewModels;
using BlacksunForms;
using BlacksunForms.Controls;
using BlacksunForms.Layouts;
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
                new DataFormDataField(){Label = "Username",DataMemberBindingPath = "Username",LabelType = LabelType.Watermark},
                new DataFormPasswordField(){Label = "Password",DataMemberBindingPath = "Password",LabelType = LabelType.Watermark},
                new DataFormButton(){Text = "Login"}
                
            });
        }

    }
}
