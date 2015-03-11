﻿using System;
using Blacksun.XamForms.Resources;
using Xamarin.Forms;

namespace Blacksun.XamForms.Controls
{
    public class DataFormLabelField: ContentView
    {

        public static BindableProperty DataMemberBindingProperty =
        BindableProperty.Create<DataFormLabelField, string>(ctrl => ctrl.DataMemberBinding,
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (DataFormLabelField)bindable;
            ctrl.DataMemberBinding = newValue;
        });


        public string DataMemberBinding
        {
            get { return (string)GetValue(DataMemberBindingProperty); }
            set
            {
                SetValue(DataMemberBindingProperty, value);
                TextField.Text = value;
            }
        }

        private StackLayout Container = new StackLayout() { Spacing = AppLayouts.LabelPropertySpacing, Padding = 0 };

        public Label LabelField = new Label(){
                Font = AppFonts.FormLabelFont,
                TextColor = AppColors.FormLabelColor,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };


        private Label TextField = new Label()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand
        };
        
        private string _label;
        public string Label
        {
            get { return LabelField.Text; }
            set
            {
                LabelField.Text = value;
                if (String.IsNullOrEmpty(Label))
                {
                    if (Container.Children.Contains(LabelField))
                        Container.Children.Remove(LabelField);
                }
                else
                {
                    if(!Container.Children.Contains(LabelField))
                        Container.Children.Insert(0,LabelField);
                }
            }
        }
        /*
        public string DataMemberBinding
        {
            get { return TextField.Text; }
            set
            {
                TextField.Text = value;
                OnPropertyChanged();
            }
        }*/

        private string _dataMemberBindingPath;
        public string DataMemberBindingPath
        {
            get { return _dataMemberBindingPath; }
            set
            {
                _dataMemberBindingPath = value;
                TextField.SetBinding(Xamarin.Forms.Label.TextProperty, new Binding(value, BindingMode.TwoWay));
            }
        }


        public DataFormLabelField()
        {
            TextField.PropertyChanged += (o, t) =>
            {
                if (t.PropertyName == "Text")
                {
                    SetValue(DataMemberBindingProperty, TextField.Text);
                }
            };
            Container.Children.Add(TextField);
            Content = Container;

        }

        
        

        //public Entry Content { get; set; }



    }
}