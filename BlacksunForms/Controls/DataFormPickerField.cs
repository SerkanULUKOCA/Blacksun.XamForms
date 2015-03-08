using System;
using System.Collections.Generic;
using Blacksun.XamForms.CustomControls;
using Blacksun.XamForms.Resources;
using Xamarin.Forms;

namespace Blacksun.XamForms.Controls
{
    public class DataFormPickerField : ContentView
    {

        public static BindableProperty DataMemberBindingProperty =
        BindableProperty.Create<DataFormPickerField, object>(ctrl => ctrl.DataMemberBinding,
        defaultValue: null,
        defaultBindingMode: BindingMode.Default,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (DataFormPickerField)bindable;
            ctrl.DataMemberBinding = newValue;
        });

        public static BindableProperty ItemsSourceProperty =
        BindableProperty.Create<DataFormPickerField, IEnumerable<object>>(ctrl => ctrl.ItemsSource,
        defaultValue: null,
        defaultBindingMode: BindingMode.Default,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (DataFormPickerField)bindable;
            ctrl.ItemsSource = newValue;
        });

        public static BindableProperty SelectedItemProperty =
        BindableProperty.Create<DataFormPickerField, object>(ctrl => ctrl.DataMemberBinding,
        defaultValue: null,
        defaultBindingMode: BindingMode.Default,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (DataFormPickerField)bindable;
            ctrl.SelectedItem = newValue;
        });


        public object DataMemberBinding
        {
            get { return GetValue(DataMemberBindingProperty); }
            set
            {
                SetValue(DataMemberBindingProperty, value);
                Picker.SelectedValue = value;
            }
        }

        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
                Picker.ItemsSource = value;
            }
        }

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set
            {
                SetValue(SelectedItemProperty, value);
                Picker.SelectedItem = value;
            }
        }


        public Label LabelField = new Label()
        {
            Font = AppFonts.FormLabelFont,
            TextColor = AppColors.FormLabelColor,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

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
                    if (!Container.Children.Contains(LabelField))
                        Container.Children.Insert(0, LabelField);
                }
            }
        }

        private StackLayout Container = new StackLayout() { Spacing = AppLayouts.LabelPropertySpacing, Padding = 0 };

        BindablePicker Picker = new BindablePicker()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
        };

        /*
        public object DataMemberBinding
        {
            get { return Picker.SelectedValue; }
            set
            {
                Picker.SelectedValue = value;
                OnPropertyChanged();
            }
        }*/

        public string DisplayMemberPath
        {
            get { return Picker.DisplayMemberPath; }
            set { Picker.DisplayMemberPath = value; }
        }

        public string SelectedValueMemberPath
        {
            get { return Picker.SelectedValueMemberPath; }
            set { Picker.SelectedValueMemberPath = value; }
        }

        private string _dataMemberBindingPath;
        public string DatamemberBindingPath
        {
            get { return _dataMemberBindingPath; }
            set
            {
                _dataMemberBindingPath = value;
                var binding = new Binding(value,BindingMode.TwoWay);
                Picker.SetBinding(BindablePicker.SelectedValueProperty, binding);
            }
        }

        private string _itemSourcePath;
        public string ItemSourcePath
        {
            get { return _itemSourcePath; }
            set
            {
                _itemSourcePath = value;
                var binding = new Binding(value, BindingMode.TwoWay);
                Picker.SetBinding(BindablePicker.ItemsSourceProperty, binding);
            }
        }

        public DataFormPickerField()
        {
            Container.Children.Clear();
            Container.Children.Add(LabelField);
            Container.Children.Add(Picker);
            Content = Container;
        }

    }
}
