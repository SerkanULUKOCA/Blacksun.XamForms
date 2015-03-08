using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksun.XamForms.UserDialogs
{
    public interface IProgressDialog : IDisposable
    {

        string Title { get; set; }
        int PercentComplete { get; set; }
        bool IsDeterministic { get; set; }
        bool IsShowing { get; }
        void SetCancel(Action onCancel, string cancelText = "Cancel");

        void Show();
        void Hide();
    }
}
