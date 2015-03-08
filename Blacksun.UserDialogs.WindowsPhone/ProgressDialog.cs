﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Blacksun.XamForms.UserDialogs;

namespace Blacksun.UserDialogs.WindowsPhone
{
    public class ProgressDialog : IProgressDialog
    {
        private readonly ProgressPopUp progress = new ProgressPopUp();

        #region IProgressDialog Members

        private string text;
        public string Title
        {
            get { return this.text; }
            set
            {
                if (this.text == value)
                    return;

                this.text = value;
                this.Refresh();
            }
        }


        private int percentComplete;
        public int PercentComplete
        {
            get { return this.percentComplete; }
            set
            {
                if (this.percentComplete == value)
                    return;

                if (value > 100)
                    this.percentComplete = 100;

                else if (value < 0)
                    this.percentComplete = 0;

                else
                    this.percentComplete = value;

                this.Refresh();
            }
        }


        public bool IsDeterministic
        {
            get { return !this.progress.IsIndeterminate; }
            set { this.progress.IsIndeterminate = !value; }
        }


        public bool IsShowing { get; private set; }


        public void SetCancel(Action onCancel, string cancelText)
        {
            this.progress.SetCancel(onCancel, cancelText);
        }


        public void Show()
        {
            if (this.IsShowing)
                return;

            this.IsShowing = true;
            this.Dispatch(this.progress.Show);
        }


        public void Hide()
        {
            if (!this.IsShowing)
                return;

            this.IsShowing = false;
            this.Dispatch(this.progress.Dismiss);
        }


        protected void Dispatch(Action action)
        {
            Deployment.Current.Dispatcher.BeginInvoke(action);
        }


        private void Refresh()
        {
            this.Dispatch(() =>
            {
                this.progress.LoadingText = this.text;
                if (this.IsDeterministic)
                {
                    this.progress.PercentComplete = this.percentComplete;
                    this.progress.CompletionText = this.percentComplete + "%";
                }
            });
        }


        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Hide();
        }

        #endregion
    }
}
