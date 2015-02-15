using Blacksun.Mvvm;

namespace Blacksun.XamForms.Sample.Core.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged();}
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

    }
}
