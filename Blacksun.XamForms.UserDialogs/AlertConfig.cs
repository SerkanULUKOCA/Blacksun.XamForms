﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksun.XamForms.UserDialogs
{
    public class AlertConfig
    {

        public string OkText { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public Action OnOk { get; set; }


        public AlertConfig()
        {
            this.OkText = "OK";
        }


        //public static AlertConfig Create(string message) {
        //    return new AlertConfig {
        //        Message = message
        //    };
        //}

        public AlertConfig SetOkText(string text)
        {
            this.OkText = text;
            return this;
        }


        public AlertConfig SetTitle(string title)
        {
            this.Title = title;
            return this;
        }


        public AlertConfig SetMessage(string message)
        {
            this.Message = message;
            return this;
        }


        public AlertConfig SetCallback(Action onOk)
        {
            this.OnOk = onOk;
            return this;
        }
    }
}
